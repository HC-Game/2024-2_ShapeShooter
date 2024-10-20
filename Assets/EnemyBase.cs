using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Rigidbody enemyRb;
    //enemyspawn
    [SerializeField]
    public enum EnemyShapes { Triangle, Square, Pentagon, Heavy, Mini}; //  �ﰢ��, �簢��, ������
    public EnemyShapes enemyShapes;
    //�ش� ������ ����
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

        switch (enemyShapes)    //������ ���� �־����!!
        {
            case EnemyShapes.Triangle: //�ﰢ��
                CurrentEnemyShape = 0;

          
                break;
            case EnemyShapes.Square://�簢��
                CurrentEnemyShape = 1;

                break;

            case EnemyShapes.Pentagon: //������
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
