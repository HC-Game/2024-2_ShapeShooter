using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : EnemyBase
{
    int[] CurrentEnemyShape = new int[3];
    public override void init()
    {

        enemyData.enemyHealth = 3;
        enemyData.CurrentEnemyShape = 0;
        enemyData.enemydamage = 1;
        enemyData.enemySpeed = 4f;
    }

    public override void MoveToPlayer()
    {
        base.MoveToPlayer();
    }


    public override void Hit(int weapon)
    {

        Debug.Log("hit");
        if (weapon == enemyData.CurrentEnemyShape)
        {           
            enemyData.enemyHealth -= 1;
            Debug.Log(enemyData.enemyHealth);
        }

        if (enemyData.enemyHealth <= 0)
        {
            Death();
            Debug.Log(123);
        }


    }

}
