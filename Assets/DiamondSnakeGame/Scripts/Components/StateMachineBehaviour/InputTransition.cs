
using DiamondSnakeGame.Scripts.Enum;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DiamondSnakeGame.Scripts.Components.StateMachineBehaviour
{
    public class InputTransition : UnityEngine.StateMachineBehaviour
    {

        [SerializeField]
        private ActionValue inputActionValue;

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
            animator.SetFloat(inputActionValue.Name(), inputActionValue.ReadValue(context));
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerActions.OnMoveAction -= InputPerformed;
        }
    }
}
