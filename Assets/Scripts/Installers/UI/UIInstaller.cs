using UI.Presenter;
using UnityEngine.Rendering;
using View;
using Zenject;

namespace Installers.UI
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuPresenter>().AsSingle();
        }
    }
}
