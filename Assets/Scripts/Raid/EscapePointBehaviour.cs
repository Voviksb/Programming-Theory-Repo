using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapePointBehaviour : MonoBehaviour
{

    [SerializeField] private Image _escapeBar;
    [SerializeField] private Canvas _escapeCanvas;
    [SerializeField] private TextMeshProUGUI _escapeText;
    private void Start()
    {
        _escapeCanvas.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StartCoroutine(EscapePlayerCountdown());
            _escapeCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StopAllCoroutines();
            _escapeBar.fillAmount = 0;
            _escapeCanvas.gameObject.SetActive(false);
        }
    }
    IEnumerator EscapePlayerCountdown()
    {
        float escapeTime = 5f;
        float currentEscapeTime = 0f;
        while (currentEscapeTime < escapeTime)
        {
            currentEscapeTime += Time.deltaTime;
            _escapeText.text = "Escape in: " + (escapeTime - currentEscapeTime).ToString("0.0") + " s";
            _escapeBar.fillAmount = currentEscapeTime / escapeTime;
            yield return null;
        }
        EscapePlayer();
        _escapeCanvas.gameObject.SetActive(false);
    }

    private void EscapePlayer()
    {
        Debug.Log("Player escaped");
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
