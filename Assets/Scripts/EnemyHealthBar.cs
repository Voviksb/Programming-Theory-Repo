using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : HealthBarBase
{
    private void LateUpdate()
    {
        transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }
}
