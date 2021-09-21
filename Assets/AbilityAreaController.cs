using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAreaController : MonoBehaviour
{    
    [SerializeField] private Transform abilityHitArea;
    [SerializeField] private GameObject abilityRange;
    [SerializeField] private float normalizedRange;

    // Update is called once per frame
    void Update()
    {
        if (AbilityJoystick.NormalSkill.Direction.magnitude != 0)
        {
            abilityRange.SetActive(true);
            abilityHitArea.transform.position = Player.Instance.transform.position + (Vector3)AbilityJoystick.NormalSkill.Direction * AbilityJoystick.NormalSkill.range;
            abilityRange.GetComponent<RectTransform>().sizeDelta = AbilityJoystick.NormalSkill.range * Vector2.one * normalizedRange;
        }
        else if (FiringJoystick.Instance.Direction.magnitude != 0)
        {
            abilityRange.SetActive(true);
            abilityHitArea.transform.position = Player.Instance.transform.transform.transform.position + (Vector3)FiringJoystick.Instance.Direction * FiringJoystick.Instance.range;
            abilityRange.GetComponent<RectTransform>().sizeDelta = FiringJoystick.Instance.range * Vector2.one * normalizedRange;          
        }    
        else
        {
            abilityRange.SetActive(false);
        }
    }
}
