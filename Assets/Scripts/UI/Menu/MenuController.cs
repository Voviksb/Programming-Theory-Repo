using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
   // [SerializeField] private Scene _raidScene;
    [SerializeField] private RaidLoadingTransition _raidLoadingTransition;

    private void Awake()
    {
        _raidLoadingTransition = new RaidLoadingTransition();
    }

    private void Update()
    {

    }
}
