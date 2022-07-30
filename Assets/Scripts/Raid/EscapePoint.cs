using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePoint : MonoBehaviour
{
    [SerializeField] private string _escapePointName;
    [SerializeField] private Vector3 _escapePosition;

    public string EscapePointName { 
        get { return _escapePointName;} 
    }
}
