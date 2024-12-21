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
    [SerializeField] private int timeLimit = 600;
    [SerializeField] private int timeInterval;
    [SerializeField] private float spawnTime = 2;
    [SerializeField] private float DecreaseTime;
    [SerializeField] private int minute, second;
    WaitForSeconds wait_1f = new WaitForSeconds(1f);

    public int killCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� GameManager�� ����
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
    }
    IEnumerator StartGameTimer()
    {
        while (timeLimit > 0)
        {
            minute = timeLimit / 60;
            second = timeLimit % 60;

            TimeText.text = $"{minute} : {second}";

            yield return wait_1f;
            timeLimit -= 1; // 1�� ����
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
