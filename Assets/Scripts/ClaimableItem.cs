using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimableItem : MonoBehaviour
{
  //  [SerializeField] private Rigidbody _rigidBody;


    private void Start()
    {
     //   StartCoroutine(DropAnimation());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StartCoroutine(ClaimItem());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            StopAllCoroutines();
        }
    }

/*    IEnumerator DropAnimation()
    {
        float animTime = 2f;
        Vector3 targetUp = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        while (animTime > 0)
        {
            animTime -= Time.deltaTime;
            transform.Translate(Vector3.Lerp(transform.position, targetUp, 1f));
            yield return null;
        }
    }*/

    IEnumerator ClaimItem()
    {
        float time = 2f;
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("Item claimed");
        this.gameObject.SetActive(false);
    }
}
