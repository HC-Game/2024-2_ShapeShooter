using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> spawnPoints = new List<Transform>();
    public GameObject[] enemys;
    Coroutine spawnRoutine;
    void Start(){
    spawnPoints = GetComponentsInChildren<Transform>().ToList();
    spawnRoutine = StartCoroutine(Spawn());
    }
    public void Play()
    {
       spawnRoutine = StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return null;
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, enemys.Length);
            ObjectPooler.SpawnFromPool($"{rand}", spawnPoints[UnityEngine.Random.Range(1, spawnPoints.Count)].position);
            yield return new WaitForSeconds(GameManager.Instance.SpawnTime);
        }
    }
    public void Stop(){
        StopCoroutine(spawnRoutine);
    }
   
}
