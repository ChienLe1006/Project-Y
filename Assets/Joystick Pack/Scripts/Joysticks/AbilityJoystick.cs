using UnityEngine;
using System.Collections;

public class AbilityJoystick : FixedJoystick
{
    public static AbilityJoystick NormalSkill;
    public int range = 4;

    private void Awake()
    {
        if (NormalSkill == null)
        {
            NormalSkill = this;
        }
    }
}
