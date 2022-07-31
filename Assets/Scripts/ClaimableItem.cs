using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimableItem : MonoBehaviour
{
    [SerializeField] private Image _itemBar;
    [SerializeField] private Canvas _itemCanvas;
    private void Start()
    {
        _itemCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.transform.RotateAround(Vector3.up, 0.004f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StartCoroutine(ClaimItem());
            _itemCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StopAllCoroutines();
            _itemBar.fillAmount = 0;
            _itemCanvas.gameObject.SetActive(false);
        }
    }

    IEnumerator ClaimItem()
    {
        float claimTime = 2f;
        float currentClaimTime = 0f;
        while (currentClaimTime < claimTime)
        {
            currentClaimTime += Time.deltaTime;
            _itemBar.fillAmount = currentClaimTime / claimTime;
            yield return null;
        }
        Debug.Log("Item claimed");
        this.gameObject.SetActive(false);
        _itemCanvas.gameObject.SetActive(false);
    }
}
