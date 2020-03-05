using DiamondSnakeGame.Scripts.Enum;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DiamondSnakeGame.Scripts.Components.StateMachineBehaviour
{
    public class Stay : UnityEngine.StateMachineBehaviour
    {
        private InputAction.CallbackContext context = default;
        private IPlayerActions playerActions;

        [Inject]
        private void Injection(IInputActionProvider provider)
        {
            playerActions = provider.InputPlayerActions;
            playerActions.OnMoveAction += InputPerformed;
        }

        private void InputPerformed(InputAction.CallbackContext context)
        {
            this.context = context;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ActionValue inputAction in System.Enum.GetValues(typeof(ActionValue)))
            {
                animator.SetFloat(inputAction.Name(), inputAction.ReadValue(context));
            }
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerActions.OnMoveAction -= InputPerformed;
        }
    }
}
