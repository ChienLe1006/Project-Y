using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Singleton<Weapon>
{
    [SerializeField] private bool isFiring;
    [SerializeField] private bool isReloading;
    [SerializeField] private Animator firingController;
    [SerializeField] private GameObject weaponController;
    private WeaponController wc;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject weaponBack;
    [SerializeField] private List<WeaponInfo> weaponList;
    private int currentWeaponIndex;


    public Animator Anim { get => anim;}
    public WeaponBehaviour WeaponBehaviour { get => wc.WeaponBehaviour; set => wc.WeaponBehaviour = value; }
    public Transform FiringPoint { get => firingPoint; set => firingPoint = value; }
    public GameObject WeaponBack { get => weaponBack; set => weaponBack = value; }
    public bool IsFiring { get => isFiring;}
    public bool IsReloading { get => isReloading; set => isReloading = value; }

    private void Start()
    {
        wc = weaponController.GetComponent<WeaponController>();
        wc.WeaponBehaviour = weaponList[0].WeaponBehaviour;
        weaponController.SetActive(false);
    }

    public void Fire(Vector2 direction)
    {
        if (!IsReloading)
        {
            Direction(direction);
            WeaponBack.SetActive(false);
            weaponController.SetActive(true);
            WeaponBehaviour.OnAttackEnter(direction);
            isFiring = true;
        }  
    }
    
    public void Direction(Vector2 direction)
    {
        wc.DX = direction.x;
        wc.DY = direction.y;
    }
    public void Stop()
    {   
        if (IsFiring)
        {
            weaponController.SetActive(false);   
            isFiring = false;
            if (!isReloading)
            {
                WeaponBack.SetActive(true);
                WeaponBehaviour.OnAttackExit(new Vector2(wc.DX, wc.DY));
            }
            
        }              
    }

    public void Reload()
    {
        weaponController.SetActive(false);
        isReloading = true;
        firingController.SetBool("IsReloading", true);
        //isFiring = false;
        firingController.SetBool("IsFiring", false);
    }

    public void FinishReload()
    {
        IsReloading = false;
        weaponController.SetActive(isFiring);
        if (!isFiring) weaponBack.SetActive(true);
        WeaponBehaviour.OnAttackEnter(new Vector2(wc.DX, wc.DY));
    }

    public void Swap()
    {
        currentWeaponIndex++;
        if (currentWeaponIndex == weaponList.Count) currentWeaponIndex = 0;
        
        WeaponInfo info = weaponList[currentWeaponIndex];

        ProjectilePool.Instance.Swap(info, currentWeaponIndex);
        Cartridge.Instance.Swap(info, currentWeaponIndex);

        weaponController.GetComponent<SpriteRenderer>().sprite = info.WeaponSprite;
        weaponController.transform.localPosition = info.WeaponPosition;

        FiringPoint.localPosition = info.FiringPointPostion;

        wc.WeaponBehaviour = info.WeaponBehaviour;

        anim.runtimeAnimatorController = info.WeaponAnim;
        anim.transform.localPosition= info.WeaponAnimPostion;
        anim.GetComponent<SpriteRenderer>().color = info.WeaponAnimColor;

        WeaponBack.GetComponent<SpriteRenderer>().sprite = info.WeaponBackSprite;
        WeaponBack.transform.localPosition = info.WeaponBackPosition;
        WeaponBack.transform.eulerAngles = info.WeaponBackRotation;
    }
}
