using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettings : MonoBehaviour
{
    [SerializeField]
    private Vector3[] _spawnPositions = new Vector3[5]
    {
        new Vector3(125, 10, 40),
        new Vector3(70, 10, 140),
        new Vector3(15, 10, 105),
        new Vector3(-32, 10, -23),
        new Vector3(20, 10, 30),
    };

    [SerializeField]
    private EscapePoint[] _escapePoints = new EscapePoint[4];

    public void InitializeEscapePositions()
    {
        int activeEscapePointsCount = Random.Range(1, _escapePoints.Length + 1);
        Debug.Log("Active escape points count will be: " + activeEscapePointsCount);

        int[] EscapePointsToActivate = new int[activeEscapePointsCount];
        for (int i = 0; i < activeEscapePointsCount; i++)
        {
            EscapePointsToActivate[i] = Random.Range(0, activeEscapePointsCount);
            Debug.Log(EscapePointsToActivate[i]);
        }

        for (int i = 0; i < _escapePoints.Length; i++)
        {
            for (int j = 0; j < EscapePointsToActivate.Length; j++)
            {
                if (i == EscapePointsToActivate[j])
                {
                    _escapePoints[j].gameObject.SetActive(true);
                    Debug.Log(_escapePoints[j].gameObject.name + " is Activated"); 
                }
            }
        }
    }

    public Vector3 SelectSpawnPosition()
    {
        Debug.Log("Selecting spawn pos");
        Vector3 spawnPosition;
        spawnPosition = _spawnPositions[Random.Range(0, 5)];
        return spawnPosition;
    }
}

public struct EscapePointPreset
{
    public string escapePointName;
    public bool isActive;
    //  public EscapePoint escapePointPrefab;

    public EscapePointPreset(string name, bool active)
    {
        escapePointName = name;
        isActive = active;
    }
}
