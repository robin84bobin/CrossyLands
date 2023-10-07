using Installers.Project;

public class ProjectStandaloneInstaller : ProjectCommonInstaller
{
#if UNITY_EDITOR || UNITY_STANDALONE
    public override void InstallBindings()
    {
        base.InstallBindings();
        BindGameplayInput();
    }

    private void BindGameplayInput()
    {
        Container.Bind<IGameplayInputService>().To<StandaloneGameplayInputService>().AsSingle().NonLazy();
    }

#endif
}