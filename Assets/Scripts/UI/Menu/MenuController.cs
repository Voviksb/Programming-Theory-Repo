using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Scene _raidScene;

    private void Awake()
    {
        _raidScene = SceneManager.GetSceneByName("RaidScene");
    }

    private void Update()
    {
    }

    public void OnStartRaidButtonClicked()
    {
        SceneManager.LoadScene("RaidScene", LoadSceneMode.Single);
    //    SceneManager.UnloadSceneAsync("MenuScene");
    }
}
