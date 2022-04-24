﻿using System;

namespace AEAssist
{
    public abstract class Entity : IDisposable
    {
        public bool IsDisposed { get; set; }


        public void Dispose()
        {
            if (IsDisposed)
                return;
            OnDestroy();
            IsDisposed = true;
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}