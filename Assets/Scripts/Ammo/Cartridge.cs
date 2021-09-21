using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cartridge : Singleton<Cartridge>, IWeaponSwap
{
    private Color grayColor = new Color(0.5803922f, 0.5294118f, 0.4235294f, 1f);
    private Color blackColor = Color.black;

    [SerializeField] private int currentIndex;
    [SerializeField] private Transform current;
    [SerializeField] private GameObject reloadBar;
    private WeaponBehaviour currentReloadingWeapon;
    
    public void ConsumeAmmo(int lastAmmoIndex)
    {
        current.GetChild(lastAmmoIndex).GetComponent<Image>().color = grayColor;
    }

    public void RestoreAmmo(int lastAmmoIndex)
    {
        current.GetChild(lastAmmoIndex).GetComponent<Image>().color = blackColor;
    }

    public void Reload(WeaponBehaviour weaponBehaviour)
    {
        currentReloadingWeapon = weaponBehaviour;
        reloadBar.SetActive(true);
        Weapon.Instance.Reload();

    }

    public void FinishReload()
    {
        currentReloadingWeapon.Reload();
        for (int i = 0; i < current.childCount; i++)
        {
            RestoreAmmo(i);
        }
    }

    public void Swap(WeaponInfo info, int index)
    {
        currentIndex = index;
        current.gameObject.SetActive(false);
        current = transform.GetChild(currentIndex);
        current.gameObject.SetActive(true);
    }
}
