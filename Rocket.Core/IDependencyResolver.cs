﻿using System;
using System.Collections.Generic;

namespace Rocket.Core
{
    public interface IDependencyResolver
    {
        T Get<T>();
        T Get<T>(params object[] parameters);
        IEnumerable<T> GetAll<T>();
        IEnumerable<T> GetAll<T>(params object[] parameters);
        bool IsRegistered<T>();
        bool IsRegistered(Type type);
        T TryGet<T>();
        T TryGet<T>(params object[] parameters);
        IEnumerable<T> TryGetAll<T>();
        IEnumerable<T> TryGetAll<T>(params object[] parameters);
        object Activate(Type type);
        object Get(Type serviceType);
        object Get(Type serviceType, params object[] parameters);
        IEnumerable<object> GetAll(Type type);
        IEnumerable<object> GetAll(Type type, params object[] parameters);
        object TryGet(Type serviceType);
        object TryGet(Type serviceType, params object[] parameters);
        IEnumerable<object> TryGetAll(Type type);
        IEnumerable<object> TryGetAll(Type type, params object[] parameters);
    }
}