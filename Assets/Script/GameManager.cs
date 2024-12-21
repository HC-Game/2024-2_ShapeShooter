using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("GamePlay Properties")]
    public Transform player;
    public Transform playerCam;
    public TextMeshProUGUI TimeText;
    private int timeLimit = 600;
    private int timeInterval;
   
    private float spawnTime = 2;
     public float SpawnTime
    {
        get{ return spawnTime; } 
    }
    private float DecreaseTime;
    private int minute, second;
    WaitForSeconds wait_1f = new WaitForSeconds(1f);

    public int killCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameStart();
        timeInterval = timeLimit / 10;
        DecreaseTime = spawnTime / 20;
        StartCoroutine(ReduceTime());
    }
    IEnumerator StartGameTimer()
    {
        yield return null;
        while (timeLimit > 0)
        {
            minute = timeLimit / 60;
            second = timeLimit % 60;

            TimeText.text = $"{minute} : {second}";

            yield return wait_1f;
            timeLimit -= 1; 
            continue;
        }
        GameWin();
    }

    private void GameWin()
    {
        throw new NotImplementedException();
    }

    private void GameOver()
    {

    }
    IEnumerator ReduceTime()
    {
        yield return null;
        while (true)
        {
         
            spawnTime -= DecreaseTime;
            Debug.Log(spawnTime);
            yield return new WaitForSeconds(timeInterval);
        }
    }


    public void GameStart()
    {

        StartCoroutine(StartGameTimer());
    }
    public void KillUp()
    {
        killCount++;
    }
}
