using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaidLoadingTransition : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _loadingText;

    private void Awake()
    {

    }

    public async void LoadRaid(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
          StartCoroutine(LoadRaidAsync(sceneIndex));
    }

    IEnumerator LoadRaidAsync(int sceneIndex)
    {
        
        float elapsedLoadingTime = 0f;
        const float MAX_LOADING_TIME = 4F;
        float loadingProgress;

        while (elapsedLoadingTime <= 1.5f)
        {
            loadingProgress = Mathf.Clamp01(elapsedLoadingTime / MAX_LOADING_TIME);
            _slider.value = loadingProgress;
            _loadingText.text = "Loading: " + (loadingProgress * 100f).ToString("0") + " %";
            elapsedLoadingTime += Time.deltaTime;
            yield return null;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            loadingProgress = Mathf.Clamp01(elapsedLoadingTime / MAX_LOADING_TIME);
            _slider.value = loadingProgress;
             _loadingText.text = "Loading: " + (loadingProgress * 100f).ToString("0") + " %";
            elapsedLoadingTime += Time.deltaTime;
            yield return null;
        }

        while (elapsedLoadingTime <= MAX_LOADING_TIME)
        {
            loadingProgress = Mathf.Clamp01(elapsedLoadingTime / MAX_LOADING_TIME);
            _slider.value = loadingProgress;
            _loadingText.text = "Loading: " + (loadingProgress * 100f).ToString("0") + " %";
            elapsedLoadingTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
        operation.allowSceneActivation = true;
    }
}
