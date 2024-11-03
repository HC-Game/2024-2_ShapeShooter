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
            if (instance == null)
            {
                Debug.LogError("GameManager instance is null! Make sure GameManager is in the scene.");
            }
            return instance;
        }
    }
 
    public Transform player;
    public Transform playerCam;

    public TextMeshProUGUI TimeText;
    public int timeLimit = 600;
 
    public int minute,second;
    WaitForSeconds wait_1f = new WaitForSeconds(1f);

    IEnumerator StartGameTimer()
    {
        while (timeLimit>0) { 
        minute= timeLimit / 60;
        second= timeLimit % 60;

        TimeText.text = $"{minute} : {second}";

        yield return wait_1f;
        timeLimit -= 1; // 1�� ����
        continue;
        }
        TimeOver();
    }


    private void TimeOver()
    {
        
    }

    // Awake is called before Start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� GameManager�� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ߺ��� ������Ʈ�� ����
        }
    }

    private void Start()
    {
        GameStart();
    }
    public void GameStart()
    {
      
        StartCoroutine(StartGameTimer());
    }

}
