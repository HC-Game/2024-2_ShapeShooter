using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float lifeTime;

    void OnEnable()
    {
       StartCoroutine(RoteateRoutine());
    }
    void FixedUpdate()
    {
        transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.up);
    }
    IEnumerator RoteateRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
  
    void OnTriggerEnter(Collider other){
       if(other.CompareTag("Player")){
        GameManager.Instance.player.Health++;
        AudioManager.Instance.PlaySFX("Heal");
        gameObject.SetActive(false);}
    }
}
