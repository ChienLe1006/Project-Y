using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringJoystick : VariableJoystick
{
    
    public int range = 3;

    
    public static FiringJoystick Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
