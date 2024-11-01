using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> spawnPoints = new List<Transform>();
    public GameObject[] enemy;
    public Transform enemyParent;
    
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>().ToList();
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn()
    {
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, 2);
            ObjectPooler.SpawnFromPool($"{rand}", spawnPoints[UnityEngine.Random.Range(1, spawnPoints.Count)].position);
            yield return new WaitForSeconds(2f);
        }
    }

    
}
