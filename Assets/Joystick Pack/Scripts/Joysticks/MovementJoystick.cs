using System.Collections;
using UnityEngine;

public class MovementJoystick : VariableJoystick
{
    public static MovementJoystick Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
