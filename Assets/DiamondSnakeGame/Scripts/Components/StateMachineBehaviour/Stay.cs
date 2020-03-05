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
        private void Injection(IPlayerActions playerActions)
        {
            this.playerActions = playerActions;
            Debug.Log($"inject");
        }

        private void InputPerformed(InputAction.CallbackContext context)
        {
            this.context = context;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerActions.OnMoveAction += InputPerformed;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (ActionValue inputAction in System.Enum.GetValues(typeof(ActionValue)))
            {
                Debug.Log(inputAction.ReadValue(context));
                animator.SetFloat(inputAction.Name(), inputAction.ReadValue(context));
            }
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerActions.OnMoveAction -= InputPerformed;
        }
    }
}
