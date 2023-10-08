using System;
using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    internal class HeroModel : IHeroModel, IInitializable, ITickable, IDisposable
    {
        public HeroModel()
        {
        }

        public void Foo()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            Debug.Log($"{this} : Initialize");
        }

        public void Tick()
        {
            Debug.Log($"{this} : Tick");
        }

        public void Dispose()
        {
            Debug.Log($"{this} : Dispose");
        }
    }
}