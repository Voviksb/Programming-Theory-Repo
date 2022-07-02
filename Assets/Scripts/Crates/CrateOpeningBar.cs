using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpeningBar : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
    }
}
