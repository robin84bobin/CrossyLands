﻿using System;

namespace Commands
{
    public abstract class Command
    {
        public event Action OnComplete = delegate { };
        public abstract void Execute();

        protected virtual void Release()
        {
            OnComplete = null;
        }

        protected virtual void Complete()
        {
            OnComplete.Invoke();
            Release();
        }
    }
}