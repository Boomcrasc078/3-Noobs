using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{

    public enum PlayerInputActionType
    {
        Float,
        Bool
    };

    [Serializable]
    public struct PlayerInputAction
    {
        [SerializeField] string name;
        [SerializeField] InputActionReference inputAction;
        [SerializeField] private PlayerInputActionType playerInputActionType;
    }



    [SerializeField] private PlayerInput playerInput;
    [SerializeField] PlayerInputAction[] playerInputActions;



    void Update()
    {
    }

    float GetFloatFromAction(PlayerInputActionType playerInputActionType)
    {
        return playerInput.actions.
        }

    public float GetMoveVector()
    {
        return GetFloatFromAction("Move");
    }
}