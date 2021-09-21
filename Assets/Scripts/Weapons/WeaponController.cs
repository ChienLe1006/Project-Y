using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponBehaviour weaponBehaviour;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float dX;
    [SerializeField] private float dY;

    public WeaponBehaviour WeaponBehaviour { get => weaponBehaviour; set => weaponBehaviour = value; }
    public float DX { get => dX; set => dX = value; }
    public float DY { get => dY; set => dY = value; }

    private void FixedUpdate()
    {
        WeaponBehaviour.OnAttackUpdate(new Vector2(DX, DY));
        OnJoystickScroll();
    }

    private void OnJoystickScroll()
    {
        if (DX < 0)
        {
            rotation.y = 0;
            rotation.z = Mathf.Atan(DY / DX) * Mathf.Rad2Deg;
        }
        else if (DX > 0)
        {
            rotation.y = 180;
            rotation.z = -Mathf.Atan(DY / DX) * Mathf.Rad2Deg;
        }
        transform.eulerAngles = rotation;
    }
}
