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
    public void Init()
    {
        currentShapeIndex = new int[heavyEnemyShapes.GetLength(1)];

        var randomRow = Random.Range(0, heavyEnemyShapes.GetLength(0));
      
        for (int i = 0; i < heavyEnemyShapes.GetLength(1); i++)
        {
            // 무작위로 행 선택 후, 해당 열 값을 저장
            currentShapeIndex[i] = heavyEnemyShapes[randomRow, i];
        }

        // 결과 출력
        Debug.Log("현재 선택된 모양: " + string.Join(", ", currentShapeIndex));

        EnemyData.enemySpeed = 1f;
        EnemyData.enemyHealth = 3;
        EnemyData.CurrentEnemyShape = 4;
        EnemyData.enemydamage = 1;
    }

    public override void MoveToPlayer()
    {
        base.MoveToPlayer();
    }
    public override void Hit(int weapon)
    {

        Debug.Log("hit");
        if (weapon == EnemyData.CurrentEnemyShape)
        {
            EnemyData.enemyHealth -= 1;
            Debug.Log(EnemyData.enemyHealth);
        }

        if (EnemyData.enemyHealth <= 0)
        {
            Death();
            Debug.Log(123);
        }


    }

}
