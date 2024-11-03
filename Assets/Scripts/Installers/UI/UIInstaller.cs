using UI.Presenter;
using View;
using Zenject;

namespace Installers.UI
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMainMenuPresenter>().To<MainMenuPresenter>().AsCached();
        }
    }
}
