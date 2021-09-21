using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOController : MonoBehaviour
{
    [SerializeField] private List<ArmoryBehaviour> list;
    void Start()
    {
        foreach(ArmoryBehaviour armoryBehaviour in list)
        {
            armoryBehaviour.OnGameStart();
        }
    }
}
