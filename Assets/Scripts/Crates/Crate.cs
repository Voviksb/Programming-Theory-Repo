using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    [SerializeField] private GameObject _crateModel;
    [SerializeField] private CrateConfig _crateConfig;
    [SerializeField] private string _crateType;
    [SerializeField] private string _rarity;
    [SerializeField] private float _unlockTime;
    [SerializeField] private GameObject _reward;
    [SerializeField] private Image _crateBar;
    [SerializeField] private Canvas _crateCanvas;
    [SerializeField] private AudioSource _crateSource;
    [SerializeField] private GameObject _crateInstance;
    private bool _isUnlocked;

    void Start()
    {
        _crateModel = _crateConfig.crateModel;
        _crateInstance = Instantiate(_crateModel, this.transform.position, _crateModel.transform.rotation);
        _crateInstance.transform.parent = this.transform;
        _crateType = _crateConfig.crateType;
        _rarity = _crateConfig.rarity;
        _crateCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StartCoroutine(UnlockCrate());
            _crateCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            if (!_isUnlocked)
            {
                StopAllCoroutines();
                _crateBar.fillAmount = 0;
                _crateCanvas.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator UnlockCrate()
    {
        float unlockTime = 2f;
        float currentUnlockTime = 0f;
        while (currentUnlockTime < unlockTime)
        {
            currentUnlockTime += Time.deltaTime;
            _crateBar.fillAmount = currentUnlockTime / unlockTime;
            yield return null;
        }
        _isUnlocked = true; 
        _crateSource.PlayOneShot(_crateSource.clip);
        HideCrate();
        DropItems();
        yield return new WaitForSeconds(_crateSource.clip.length);
        this.gameObject.SetActive(false);
    }

    private void HideCrate()
    {
        _crateCanvas.gameObject.SetActive(false);
        _crateInstance.gameObject.SetActive(false);
    }

    private void DropItems()
    {
        var reward = Instantiate(_reward, this.transform.position + Vector3.up * 2f, Quaternion.LookRotation(Vector3.left));
       /* Rigidbody rewardRb = reward.GetComponent<Rigidbody>();
        rewardRb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
        reward.transform.position = Vector3.Lerp(reward.transform.position, Vector3.up * 2f, 3f);*/
    }

    //IEnumerator 
}
