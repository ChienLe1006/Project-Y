using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float timeScale;

    private void Start()
    {
        timeScale = 1f;
    }
    void Update()
    {
        Time.timeScale = timeScale;
    }
}
