using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DiamondSnakeGame.Scripts.Provider.Interface
{
    public interface IInputActionProvider
    {
        IPlayerActions InputPlayerActions { get; }
        InputManager.IUIActions InputUiActions { get; }
    }
    
    public interface IPlayerActions
    {
        event Action<InputAction.CallbackContext> OnMoveAction;
        event Action<InputAction.CallbackContext> OnLookAction;
        InputAction.CallbackContext MoveContext { get; }
    }
}
