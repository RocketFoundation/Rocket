using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Rocket.API.Utils
{
    public class TaskDispatcher : MonoBehaviour
    {
        public static TaskDispatcher Instance { get; private set; }

        private static readonly List<Action> QueuedMainActions = new List<Action>();
        private static readonly List<Action> QueuedMainActionsBuffer = new List<Action>();

        private static readonly List<Action> QueuedMainFixedActions = new List<Action>();
        private static readonly List<Action> QueuedMainFixedActionsBuffer = new List<Action>();

        private static readonly List<Action> QueuedAsyncActions = new List<Action>();
        private static readonly List<Action> QueuedAsyncActionsBuffer = new List<Action>();

        private static int _mainThreadId;
        private Thread _thread;

        //This will allow greater control over the interation of the secondary Thread.
        private bool runThread = default(bool);

        protected void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        protected void Start()
        {
            runThread = true;

            _mainThreadId = Thread.CurrentThread.ManagedThreadId;
            _thread = new Thread(AsyncUpdate);
            _thread.Start();
        }

        public bool IsCurrentThreadMainThread => Thread.CurrentThread.ManagedThreadId == _mainThreadId;

        /// <summary>
        /// Calls the action on the main thread on the next Update()
        /// </summary>
        /// <param name="action">The action to queue for the next Update() call</param>
        public void QueueUpdate(Action action)
        {
            lock (QueuedMainActionsBuffer)
            {
                QueuedMainActionsBuffer.Add(action);
            }
        }
        /// <summary>
        /// Runs the given action on the main thread. Will invoke immediately if the current thread is the main thread, will queue if not.
        /// </summary>
        /// <param name="action">The action to run on the main thread</param>
        public void RunOnMainThread(Action action)
        {
            if (IsCurrentThreadMainThread) action.Invoke();
            else QueueUpdate(action);
        }

        /// <summary>
        /// Calls the action on the main thread on the next FixedUpdate()
        /// </summary>
        /// <param name="action">The action to queue for thenext FixedUpdate() call</param>
        public void QueueUpdateFixed(Action action)
        {
            lock (QueuedMainFixedActionsBuffer)
            {
                QueuedMainFixedActionsBuffer.Add(action);
            }
        }

        /// <summary>
        /// Calls the action on the next async thread Update() call
        /// </summary>
        /// <param name="action">The action to call async</param>
        public void QueueAsync(Action action)
        {
            lock (QueuedAsyncActionsBuffer)
            {
                QueuedAsyncActionsBuffer.Add(action);
            }
        }

        private static int numThreads;
        public static void RunAsync(Action a)
        {
            while (numThreads >= 8)
            {
                Thread.Sleep(1);
            }
            Interlocked.Increment(ref numThreads);
            ThreadPool.QueueUserWorkItem(RunAction, a);
        }

        private static void RunAction(object action)
        {
            try
            {
                ((Action)action)();
            }
            catch (Exception)
            {
            }
            finally
            {
                Interlocked.Decrement(ref numThreads);
            }
        }

        protected void Update()
        {
            lock (QueuedMainActionsBuffer)
            {
                if (QueuedMainActionsBuffer.Count != 0)
                {
                    QueuedMainActions.AddRange(QueuedMainActionsBuffer);
                    QueuedMainActionsBuffer.Clear();
                }
            }

            if (QueuedMainActions.Count != 0)
            {
                for (int i = 0; i < QueuedMainActions.Count; i++)
                {
                    QueuedMainActions[i].Invoke();
                }

                QueuedMainActions.Clear();
            }
        }

        protected void FixedUpdate()
        {
            lock (QueuedMainFixedActionsBuffer)
            {
                if (QueuedMainFixedActionsBuffer.Count != 0)
                {
                    QueuedMainFixedActions.AddRange(QueuedMainFixedActionsBuffer);
                    QueuedMainFixedActionsBuffer.Clear();
                }
            }

            if (QueuedMainFixedActions.Count != 0)
            {
                for (int i = 0; i < QueuedMainFixedActions.Count; i++)
                {
                    QueuedMainFixedActions[i].Invoke();
                }

                QueuedMainFixedActions.Clear();
            }
        }

        private void AsyncUpdate()
        {
            //It wouldn't interate more than once without this.
            while (runThread)
            {
                Thread.Sleep(10);

                lock (QueuedAsyncActionsBuffer)
                {
                    if (QueuedAsyncActionsBuffer.Count != 0)
                    {
                        QueuedAsyncActions.AddRange(QueuedAsyncActionsBuffer);
                        QueuedAsyncActionsBuffer.Clear();
                    }
                }

                if (QueuedAsyncActions.Count != 0)
                {
                    for (int i = 0; i < QueuedAsyncActions.Count; i++)
                    {
                        QueuedAsyncActions[i].Invoke();
                    }

                    QueuedAsyncActions.Clear();
                }
            }
        }

        public void Shutdown()
        {
            //Instead of interrupting, just stop it from iterating and let it finish.
            runThread = false;
            _thread.Join();
            
            //Should be safe to clear these from the main Thread now that the secondary Thread has stopped.
            QueuedAsyncActionsBuffer.Clear();
            QueuedMainActionsBuffer.Clear();
            QueuedMainFixedActionsBuffer.Clear();

            //These should be empty anyway, but just to ensure.
            QueuedAsyncActions.Clear();
            QueuedMainActions.Clear();
            QueuedMainFixedActions.Clear();

            //Wouldn't join be better to avoid any I/O corruption?
            //_thread?.Interrupt();

            //Why would it restart the Thread on Shutdown?
            /*
            _thread = new Thread(AsyncUpdate);
            _thread.Start();
            */
        }
    }
}