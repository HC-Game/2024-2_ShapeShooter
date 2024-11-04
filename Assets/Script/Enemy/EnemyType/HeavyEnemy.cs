using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : EnemyBase
{
    int[] currentShapeIndex = new int[3];

    int[,] heavyEnemyShapes =
    {
        { 1, 2, 3},
        { 1, 3, 2},
        { 2, 3, 1},
        { 2, 1, 3},
        { 3, 1, 2},
        { 3, 2, 1}
    };
    public override void init()
    {

        for (int i = 0; i < heavyEnemyShapes.GetLength(1); i++)
        {
            currentShapeIndex[i] = heavyEnemyShapes[Random.Range(0,heavyEnemyShapes.GetLength(0)-1), i];
        }

        enemyData.enemySpeed = 1f;
        enemyData.enemyHealth = 3;
        enemyData.CurrentEnemyShape = 4;
        enemyData.enemydamage = 1;
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
