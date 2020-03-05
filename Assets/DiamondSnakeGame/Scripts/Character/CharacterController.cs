using DiamondSnakeGame.Scripts.Character.Interface;
using DiamondSnakeGame.Scripts.Components;
using DiamondSnakeGame.Scripts.Extensions;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace DiamondSnakeGame.Scripts.Character
{
    public class CharacterController : MonoBehaviour
    {
        
        [SerializeField]
        private CharacterView view;
        [SerializeField]
        private StateMachineBehaviourInjector injector;
        
        private ICharacterViewModel viewModel;
        private IInputActionProvider inputProvider;
        
        [Inject]
        private void Injection(ICharacterViewModel viewModel, IInputActionProvider inputProvider)
        {
            this.viewModel = viewModel;
            this.inputProvider = inputProvider;
        }
        
        void Start()
        {
            view.Setup(viewModel.CharacterModelPrefab);
            injector.InjectionTo(view.Animator);

            var playerAction = inputProvider.InputPlayerActions;
            this.UpdateAsObservable()
                .Select(x => playerAction.MoveContext.ReadValue<Vector2>())
                .TakeUntilDestroy(this)
                .Subscribe(x => {
                    view.NextPosition(x);
                });

            inputProvider.InputPlayerActions
                .OnLookObservable()
                .TakeUntilDestroy(this)
                .Subscribe(x =>
                {
                    
                });
        }
    }
}
