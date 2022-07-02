using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New crate", menuName = "Crate")]
public class CrateConfig : ScriptableObject
{
    public string crateName;
    public string crateType;
    public string rarity;
    public GameObject crateModel;
}
