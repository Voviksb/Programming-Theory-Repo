using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivePointsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _activePoint1;
    [SerializeField] private TextMeshProUGUI _activePoint2;
    [SerializeField] private TextMeshProUGUI _activePoint3;
    [SerializeField] private TextMeshProUGUI _activePoint4;
    [SerializeField] private MapSettings _map;

    TextMeshProUGUI[] activepoints;

    private void Start()
    {
        activepoints = new TextMeshProUGUI[]
        {
            _activePoint1, _activePoint2, _activePoint3, _activePoint4
        };

        EscapePoint[] activeEscapePoints = _map.GetActiveEscapePoints();

        for (int i = 0; i < _map.ActivePointsCount; i++)
        {
            activepoints[i].gameObject.SetActive(true);
            activepoints[i].text = activeEscapePoints[i].EscapePointName;
        }
    }
}
