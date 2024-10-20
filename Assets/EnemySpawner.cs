using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> spawnPoints = new List<Transform>();
    public GameObject enemy;
    
    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>().ToList();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int rand = UnityEngine.Random.Range(1, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[rand]);
        yield return new WaitForSeconds(4f);
    }
}
