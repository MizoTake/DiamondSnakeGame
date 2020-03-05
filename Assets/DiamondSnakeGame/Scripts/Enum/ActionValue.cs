using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DiamondSnakeGame.Scripts.Enum
{
    public enum ActionValue
    {
        MoveX,
        MoveY
    }

    public static class ActionExtension
    {
        private static Dictionary<ActionValue, string> actionValueString = new Dictionary<ActionValue, string>();

        public static string Name(this ActionValue action)
        {
            if (actionValueString.TryGetValue(action, out var value))
            {
                return value;
            }
            actionValueString.Add(action, action.ToString());
            return actionValueString[action];
        }
        
        public static float ReadValue(this ActionValue action, InputAction.CallbackContext context)
        {
            switch (action)
            {
                case ActionValue.MoveX:
                    var leftX = context.ReadValue<Vector2>().x;
                    var normalizeX = (leftX + 1f) / 2f;
                    return normalizeX;
                case ActionValue.MoveY:
                    var leftY = context.ReadValue<Vector2>().y;
                    var normalizeY = (leftY + 1f) / 2f;
                    return normalizeY;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }
    }
}
