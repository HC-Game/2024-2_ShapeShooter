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
    public int timeLimit = 600;
    public int minute,second;
    WaitForSeconds wait_1f = new WaitForSeconds(1f);

    public int killCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 GameManager를 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameStart();
    }
    IEnumerator StartGameTimer()
    {
        while (timeLimit>0) { 
        minute= timeLimit / 60;
        second= timeLimit % 60;

        TimeText.text = $"{minute} : {second}";

        yield return wait_1f;
        timeLimit -= 1; // 1초 감소
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

  

    public void GameStart()
    {
      
        StartCoroutine(StartGameTimer());
    }
    public void KillUp()
    {
        killCount++;
    }
}
