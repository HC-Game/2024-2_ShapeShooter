using System.Collections;
using System.Collections.Generic;
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
 
    public Rigidbody player;
    public Transform playerCam;

    // Awake is called before Start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 GameManager를 유지
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 중복된 오브젝트를 삭제
        }
    }

    //enemyspawn
    [SerializeField]
    public int[] AllEnemyShapes = { 0, 1, 2 }; // 1 : 삼각형,2 :사각형, 3 :오각형

}
