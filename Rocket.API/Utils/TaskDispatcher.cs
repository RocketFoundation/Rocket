using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Rocket.API.Utils
{
    public class TaskDispatcher : MonoBehaviour
    {
        public static TaskDispatcher Instance { get; private set; }

        private static readonly Queue<Action> QueuedMainActions = new Queue<Action>();
        private static readonly Queue<Action> QueuedMainActionsBuffer = new Queue<Action>();

        private static readonly Queue<Action> QueuedMainFixedActions = new Queue<Action>();
        private static readonly Queue<Action> QueuedMainFixedActionsBuffer = new Queue<Action>();

        private static readonly Queue<Action> QueuedAsyncActions = new Queue<Action>();
        private static readonly Queue<Action> QueuedAsyncActionsBuffer = new Queue<Action>();

        private static int _mainThreadId;
        private Thread _thread;

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
                QueuedMainActionsBuffer.Enqueue(action);
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
                QueuedMainFixedActionsBuffer.Enqueue(action);
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
                QueuedAsyncActionsBuffer.Enqueue(action);
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
                while (QueuedMainActionsBuffer.Count != 0)
                {
                    QueuedMainActions.Enqueue(QueuedMainActionsBuffer.Dequeue());
                }
            }

            while (QueuedMainActions.Count != 0)
            {
                QueuedMainActions.Dequeue().Invoke();
            }
        }

        protected void FixedUpdate()
        {
            lock (QueuedMainFixedActionsBuffer)
            {
                while (QueuedMainFixedActionsBuffer.Count != 0)
                {
                    QueuedMainFixedActions.Enqueue(QueuedMainFixedActionsBuffer.Dequeue());
                }
            }

            while (QueuedMainFixedActions.Count != 0)
            {
                QueuedMainFixedActions.Dequeue().Invoke();
            }
        }

        private void AsyncUpdate()
        {
            lock (QueuedAsyncActionsBuffer)
            {
                while (QueuedAsyncActionsBuffer.Count != 0)
                {
                    QueuedAsyncActions.Enqueue(QueuedAsyncActionsBuffer.Dequeue());
                }
            }

            while (QueuedAsyncActions.Count != 0)
            {
                QueuedAsyncActions.Dequeue().Invoke();
            }

            Thread.Sleep(10);
        }

        public void Shutdown()
        {
            lock (QueuedAsyncActionsBuffer)
            {
                QueuedAsyncActionsBuffer?.Clear();
            }

            lock (QueuedMainActionsBuffer)
            {
                QueuedMainActionsBuffer?.Clear();
            }

            lock (QueuedMainFixedActionsBuffer)
            {
                QueuedMainFixedActionsBuffer?.Clear();
            }

            _thread?.Interrupt();
            _thread = new Thread(AsyncUpdate);
            _thread.Start();
        }
    }
}