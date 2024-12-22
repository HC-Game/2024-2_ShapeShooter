using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public PlayerController player;
    public Transform playerCam;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI KillCountText;
    [SerializeField] private int timeLimit = 600;
    [SerializeField] private int timeInterval;
   
    [SerializeField] private float spawnTime = 2;
     public float SpawnTime
    {
        get{ return spawnTime; } 
    }
    private float DecreaseTime;
    private int minute, second;
    WaitForSeconds wait_1f = new WaitForSeconds(1f);
    [SerializeField] EnemySpawner spanwer;
    [SerializeField] GameObject gameClearUI;
    
    [SerializeField] GameObject gameOverUI;
    public int killCount;
    public int ItemCount;
    public GameObject Item;
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
        GameClear();
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
        gameClearUI.SetActive(false);
        gameOverUI.SetActive(false);
        timeInterval = timeLimit / 10;
        DecreaseTime = spawnTime / 20;
        StartCoroutine(StartGameTimer());
        StartCoroutine(ReduceTime());
        AudioManager.Instance.StopBGM("MenuBGM");
        AudioManager.Instance.PlayBGM("InGameBGM");
         Time.timeScale=1;
    }
    public void KillUp()
    {
        killCount++;
        KillCountText.text = $"Kill : {killCount}";

    }

    public bool CheckItem(){
        if (GameManager.Instance.killCount%ItemCount == 0)
        return true;
        else
        return false;
    }

    public void ItemSpawn(Transform enemyPos)
    {
        ObjectPooler.SpawnFromPool("HealthItem",enemyPos.position);
    }

    public void GameClear()
    {
          AudioManager.Instance.PlaySFX("Clear");
          spanwer.Stop();
          StopAllCoroutines();
          Cursor.lockState= CursorLockMode.Confined;
          gameClearUI.gameObject.SetActive(true);
           Time.timeScale=0;
    }

    public void GameOver()
    {
        AudioManager.Instance.PlaySFX("GameOver");
        spanwer.Stop();
        StopAllCoroutines();
        Cursor.lockState= CursorLockMode.Confined;
        gameOverUI.gameObject.SetActive(true);
        Time.timeScale=0;

    }
       public void GamePlay()
    {
        spanwer.Play();
    }

     public void GoToMain()
    {
        SceneManager.LoadScene(0);
         gameOverUI.gameObject.SetActive(false);
        gameClearUI.gameObject.SetActive(false);
      
    }
}
