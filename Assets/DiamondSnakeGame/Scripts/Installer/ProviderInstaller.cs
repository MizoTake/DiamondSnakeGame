using DiamondSnakeGame;
using DiamondSnakeGame.Scripts.Provider;
using DiamondSnakeGame.Scripts.Provider.Interface;
using Zenject;

public class ProviderInstaller : Installer<ProviderInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IDataProvider>().To<DataProvider>().AsSingle();
        Container.Bind<InputManager.IPlayerActions>().To<InputActionProvider.PlayerActions>().AsSingle();
        Container.Bind<InputManager.IUIActions>().To<InputActionProvider.UIActions>().AsSingle();
        Container.Bind<IInputActionProvider>().To<InputActionProvider>().AsSingle();
    }
}