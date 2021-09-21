using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Info", menuName = "Hung/WeaponInfo/New")]
public sealed class WeaponInfo : ScriptableObject
{
    [SerializeField] private Sprite weaponSprite;
    [SerializeField] private Vector3 weaponPosition;

    [SerializeField] private WeaponBehaviour weaponBehaviour;

    [SerializeField] private RuntimeAnimatorController weaponAnim;
    [SerializeField] private Vector3 weaponAnimPostion;
    [SerializeField] private Color weaponAnimColor;

    [SerializeField] private Vector3 firingPointPostion;

    [SerializeField] private float weaponBulletSpeed;
    [SerializeField] private GameObject weaponBullet;
    [SerializeField] private GameObject weaponBulletCollisionEffect;

    [SerializeField] private Sprite weaponBackSprite;
    [SerializeField] private Vector3 weaponBackPosition;
    [SerializeField] private Vector3 weaponBackRotation;

    [SerializeField] private GameObject cartridge;

    public Sprite WeaponSprite { get => weaponSprite;}
    public Vector3 WeaponPosition { get => weaponPosition;}
    public WeaponBehaviour WeaponBehaviour { get => weaponBehaviour;}
    public RuntimeAnimatorController WeaponAnim { get => weaponAnim;}
    public Vector3 WeaponAnimPostion { get => weaponAnimPostion;}
    public GameObject WeaponBullet { get => weaponBullet;}
    public Color WeaponAnimColor { get => weaponAnimColor;}
    public Sprite WeaponBackSprite { get => weaponBackSprite;}
    public Vector3 WeaponBackPosition { get => weaponBackPosition;}
    public Vector3 WeaponBackRotation { get => weaponBackRotation;}
    public Vector3 FiringPointPostion { get => firingPointPostion;}
    public float WeaponBulletSpeed { get => weaponBulletSpeed;}
}
