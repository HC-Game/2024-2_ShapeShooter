using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Rigidbody enemyRb;
   
    //해당 몬스터의 도형
    [SerializeField]
    int CurrentEnemyShape;

    [SerializeField]
    int enemyHealth = 1;

    [SerializeField]
    protected float enemySpeed = 1f;
    public int EnemyHealth
    {
        get { return enemyHealth; }

        set
        {
            Debug.Log(enemyHealth);
            enemyHealth = value;
            if (enemyHealth < 0)
            {
                enemyHealth = 0;
                Death();
            }
        }
    }


    [SerializeField]
    int enemydamage = 5;
    public int Enemydamage
    {
        get { return enemydamage; }
    }




    public void init()
    {
        enemyRb = GetComponent<Rigidbody>();
        CurrentEnemyShape = RandomShape();
    }

    int RandomShape()
    {
        return GameManager.Instance.AllEnemyShapes[Random.Range(0, 2)];
    }

    void Death()
    {
        gameObject.SetActive(false);
    }

}
