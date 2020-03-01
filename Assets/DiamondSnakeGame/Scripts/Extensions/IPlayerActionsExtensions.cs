using System;
using DiamondSnakeGame.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DiamondSnakeGame.Scripts.Extensions
{
    public static class IPlayerActionsExtensions
    {
        public static IObservable<Vector2> OnMoveObservable(this IPlayerActions playerActions)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(handle => playerActions.OnMoveAction += handle, handle => playerActions.OnMoveAction -= handle).Select(x => x.ReadValue<Vector2>());
        }
        
        public static IObservable<Vector2> OnLookObservable(this IPlayerActions playerActions)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(handle => playerActions.OnLookAction += handle, handle => playerActions.OnLookAction -= handle).Select(x => x.ReadValue<Vector2>());
        }
    }
}
