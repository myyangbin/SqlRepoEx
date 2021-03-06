﻿using System;
using System.Linq.Expressions;

namespace SqlRepoEx.SqlServer
{
    public delegate T EntityActivator<T>();

    public static class EntityActivator
    {
        public static EntityActivator<T> GetActivator<T>()
        {
            var type = typeof(T);
            var ctor = type.GetConstructor(Type.EmptyTypes);

            var lambda =
                Expression.Lambda(typeof(EntityActivator<T>), Expression.New(ctor));

            var compiled = (EntityActivator<T>) lambda.Compile();
            return compiled;
        }
    }
}