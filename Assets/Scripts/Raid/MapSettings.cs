using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettings : MonoBehaviour
{
    [SerializeField]
    static private Vector3[] _spawnPositions = new Vector3[5]
    {
        new Vector3(125, 10, 40),
        new Vector3(70, 10, 140),
        new Vector3(15, 10, 105),
        new Vector3(-32, 10, -23),
        new Vector3(20, 10, 30),
    };

    [SerializeField] private EscapePoint[] _escapePoints;
    public int ActivePointsCount { get; set; }

    private void Awake()
    {
        InitializeEscapePositions();
    }

    public EscapePoint[] GetActiveEscapePoints()
    {
        return _escapePoints;
    }

    public void InitializeEscapePositions()
    {
        ActivePointsCount = Random.Range(1, _escapePoints.Length + 1);
        Debug.Log("Active escape points count will be: " + ActivePointsCount);

        int[] EscapePointsToActivate = new int[ActivePointsCount];
        for (int i = 0; i < ActivePointsCount; i++)
        {
            EscapePointsToActivate[i] = Random.Range(0, ActivePointsCount);
            Debug.Log(EscapePointsToActivate[i]);
        }

        for (int i = 0; i < _escapePoints.Length; i++)
        {
            for (int j = 0; j < EscapePointsToActivate.Length; j++)
            {
                if (i == EscapePointsToActivate[j])
                {
                    _escapePoints[EscapePointsToActivate[j]].gameObject.SetActive(true);
                    Debug.Log(_escapePoints[j].gameObject.name + j + " is Activated"); 
                }
            }
        }
    }

    static public Vector3 SelectSpawnPosition()
    {
        Debug.Log("Selecting spawn pos");
        Vector3 spawnPosition;
        spawnPosition = _spawnPositions[Random.Range(0, 5)];
        return spawnPosition;
    }
}
