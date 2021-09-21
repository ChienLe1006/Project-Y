using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 keyboardMovement; 

    private System.Random rd = new System.Random();
    void Update()
    {
        keyboardMovement.x = Input.GetAxisRaw("Horizontal");
        keyboardMovement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.F))
        {
            Weapon.Instance.Swap();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Enemy.Instance.Heal(500);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Weapon.Instance.WeaponBehaviour.GetType() != typeof(BoomerangWeapon))
            {
                Cartridge.Instance.Reload(Weapon.Instance.WeaponBehaviour);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            
        }
    }
}
