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
    private EscapePoint[] escapePoints = new EscapePoint[4];

    private void Awake()
    {
        /*escapePoints[0] = new EscapePointPreset("ac", true);
        escapePoints[1] = new EscapePointPreset("ac", true);
        escapePoints[2] = new EscapePointPreset("ac", true);
        escapePoints[3] = new EscapePointPreset("ac", true);*/
    }

    public void InitializeEscapePositions(int[] activePos)
    {
        for(int i = 0; i < escapePoints.Length; i++)
        {
            for (int j = 0; j < activePos.Length; j ++)
            {
                if (i == j)
                {
                    escapePoints[i].isActive = true;
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
