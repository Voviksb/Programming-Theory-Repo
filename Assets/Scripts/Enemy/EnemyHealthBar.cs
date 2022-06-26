using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBarBase
{
    [SerializeField] private GameObject _healthBarBackground;
    private void OnEnable()
    {
        _healthBarBackground.SetActive(true);
    }
    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, Mathf.Clamp(Camera.main.transform.position.y, 0f, 180f), Camera.main.transform.position.z));
    }

    protected override void OnDamageReceived(float valueAsPercentage)
    {
        base.OnDamageReceived(valueAsPercentage);
        if (valueAsPercentage == 0)
        {
            _healthBarBackground.SetActive(false);
        }
    }
}
