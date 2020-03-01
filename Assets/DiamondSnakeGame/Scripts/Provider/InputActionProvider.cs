using System;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DiamondSnakeGame.Scripts.Provider
{
    public class InputActionProvider : IInitializable, IDisposable, IInputActionProvider
    {
        
        private InputManager input;
        private InputManager.IPlayerActions playerActions;
        private InputManager.IUIActions uiActions;
        
        public IPlayerActions InputPlayerActions => playerActions as IPlayerActions;
        public InputManager.IUIActions InputUiActions => uiActions;
        
        [Inject]
        private void Injection(InputManager.IPlayerActions playerActions, InputManager.IUIActions uiActions)
        {
            this.playerActions = playerActions;
            this.uiActions = uiActions;
            Initialize();
        }

        public void Initialize()
        {
            input = new InputManager();
            input.Player.SetCallbacks(playerActions);
//            input.UI.SetCallbacks(uiActions);
            input.Enable();
        }

        public void Dispose()
        {
            input.Disable();
        }

        public class PlayerActions : InputManager.IPlayerActions, IPlayerActions
        {

            private InputAction.CallbackContext moveContext = default;

            public event Action<InputAction.CallbackContext> OnMoveAction;
            public event Action<InputAction.CallbackContext> OnLookAction;

            public InputAction.CallbackContext MoveContext => moveContext;

            public void OnMove(InputAction.CallbackContext context)
            {
                moveContext = context;
                OnMoveAction?.Invoke(context);
            }

            public void OnLook(InputAction.CallbackContext context)
            {
                OnLookAction?.Invoke(context);
            }
        }
        
        public class UIActions : InputManager.IUIActions
        {
            public void OnNavigate(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnSubmit(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnCancel(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnPoint(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnClick(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnScrollWheel(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnMiddleClick(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnRightClick(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnTrackedDevicePosition(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }

            public void OnTrackedDeviceSelect(InputAction.CallbackContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}
