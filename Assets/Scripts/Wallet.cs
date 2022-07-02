using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _bucksCount;

    public int BucksCount {
        get { return _bucksCount; }
        set 
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException("Only positive values are allowed");

            _bucksCount = value;
        } 
    }
}
