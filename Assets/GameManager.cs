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
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� GameManager�� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ߺ��� ������Ʈ�� ����
        }
    }

    //enemyspawn
    [SerializeField]
    public int[] AllEnemyShapes = { 0, 1, 2 }; // 1 : �ﰢ��,2 :�簢��, 3 :������

}
