using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : EnemyBase
{
    [SerializeField] Transform[] ShapeHeads;
    [SerializeField] Transform[] HeadPos;
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
    public override void  init()
    {
        base.init();
        
        InitializeEnemyShape();
        UpdateShapeHeads();
        InitializeEnemyData();

    }

    private void InitializeEnemyShape()
    {
        currentShapeIndex = new int[heavyEnemyShapes.GetLength(1)];
        var randomRow = Random.Range(0, heavyEnemyShapes.GetLength(0));
    

        for (int i = 0; i < heavyEnemyShapes.GetLength(1); i++)
        {
            currentShapeIndex[i] = heavyEnemyShapes[randomRow, i];
         
        }
    }

    private void UpdateShapeHeads()
    {
        int index = 0;
        foreach (int shapeIndex in currentShapeIndex)
        {
            ShapeHeads[shapeIndex - 1].localPosition = HeadPos[index++].localPosition;
          
        }
    }

    private void InitializeEnemyData()
    {
        EnemyData.enemySpeed = 1f;
        EnemyData.enemyHealth = 3;
        EnemyData.CurrentEnemyShape = currentShapeIndex[0];
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
