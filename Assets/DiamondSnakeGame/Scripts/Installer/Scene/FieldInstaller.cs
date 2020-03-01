using DiamondSnakeGame.Scripts.Character;
using DiamondSnakeGame.Scripts.Character.Interface;
using UnityEngine;
using Zenject;

public class FieldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ICharacterViewModel>().To<CharacterViewModel>().AsTransient();
    }
}