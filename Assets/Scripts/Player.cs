using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform rigTransform;
    [SerializeField] private float movementSpeed;
   
    private Vector3 movement;
    private Vector3 keyboardMovement;

    public Vector3 Movement { get => movement; set => movement = value; }

    private void FixedUpdate()
    {
        transform.Translate((Movement + keyboardMovement)*Time.fixedDeltaTime*movementSpeed);
    }
}
