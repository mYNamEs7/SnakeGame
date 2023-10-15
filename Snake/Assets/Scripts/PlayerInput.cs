using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private Vector2 inputVector = new(0f, 1f);

    public Vector3 GetMuvementVector()
    {
        Vector2 joystickInput = new(joystick.Horizontal, joystick.Vertical);
        inputVector = joystickInput == Vector2.zero ? inputVector : joystickInput;

        return inputVector;
    }
}
