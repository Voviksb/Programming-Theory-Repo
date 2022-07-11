using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePoint : MonoBehaviour
{
    [SerializeField] private string _escapePointName;
    [SerializeField] private Vector3 _escapePosition;
    public bool isActive = false;

/*    private void Awake()
    {
        
    }*/
    void Start()
    {
        this.gameObject.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
