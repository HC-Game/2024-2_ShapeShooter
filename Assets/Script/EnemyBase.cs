using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Rigidbody enemyRb;
    //enemyspawn
    [SerializeField]
    public enum EnemyShapes { Triangle, Square, Pentagon, Heavy, Mini}; //  삼각형, 사각형, 오각형
    public EnemyShapes enemyShapes;
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

        switch (enemyShapes)    //프리펩 설정 넣어야함!!
        {
            case EnemyShapes.Triangle: //삼각형
                CurrentEnemyShape = 0;

          
                break;
            case EnemyShapes.Square://사각형
                CurrentEnemyShape = 1;

                break;

            case EnemyShapes.Pentagon: //오각형
                CurrentEnemyShape = 2;

                break;
            case EnemyShapes.Heavy:
                break;
            case EnemyShapes.Mini:
                break;
        }
    }
   

    void Death()
    {
        gameObject.SetActive(false);
    }

}
