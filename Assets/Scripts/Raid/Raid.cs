using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raid : MonoBehaviour
{
    [SerializeField] private Scene _raidScene;
    [SerializeField] private float _raidDuration;
    [SerializeField] private RaidRewards _raidRewards;



    private void GenerateRaidRewards()
    {
        //_raidRewards.GenerateRewards();
    }
}
