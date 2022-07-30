using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raid : MonoBehaviour
{
   // [SerializeField] private Scene _raidScene;
    [SerializeField] private int _raidDuration = 600;
    public event Action<string> OnTimerCountChangedEvent;
    // [SerializeField] private RaidRewards _raidRewards;

    private void Start()
    {
        StartCoroutine(RaidDurationTimer());
    }

    IEnumerator RaidDurationTimer()
    {
        while(_raidDuration > 0)
        {
            _raidDuration--;
            TimeSpan time = TimeSpan.FromSeconds(_raidDuration);
            string str = time.ToString(@"mm\:ss");
            OnTimerCountChangedEvent?.Invoke(str);
            yield return new WaitForSecondsRealtime(1);
        }
        RaidEnd();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void RaidEnd()
    {
        Debug.Log("Raid is ended");
    }

    /*async private void WaitForRaidDuration()
    {
        while(_raidDuration > 0)
        {
            await Task.Delay(1000);
            _raidDuration--;
            Debug.Log(_raidDuration);
        }
    }
*/
    private void GenerateRaidRewards()
    {
        //_raidRewards.GenerateRewards();
    }
}
