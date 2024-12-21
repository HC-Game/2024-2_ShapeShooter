using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeavyEnemy : EnemyBase
{
    [SerializeField] Transform[] HeadPos;
    int[] ShapesIndex = new int[3];
    int currentShapeIndex = 0;
    int[,] heavyEnemyShapes =
    {
    { 0, 1, 2 },
    { 0, 2, 1 },
    { 1, 2, 0 },
    { 1, 0, 2 },
    { 2, 0, 1 },
    { 2, 1, 0 }
    };
     void OnEnable()
    {    
        isDead = false;
        enemyAnimator.SetBool("IsDead", isDead);
        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
        InitializeEnemyShape();
        SetEnemyHeads();
    }
   
    private void Start() {
       InitializeEnemyData();
    }
    private void FixedUpdate() {
        MoveToPlayer();
    }

    private void InitializeEnemyShape()
    {
        var randomRow = Random.Range(0, heavyEnemyShapes.GetLength(0));

        for (int i = 0; i < heavyEnemyShapes.GetLength(1); i++)
        {
            ShapesIndex[i] = heavyEnemyShapes[randomRow, i];
              Debug.Log( "09 "+ShapesIndex[i]);
        }
    }

    private void SetEnemyHeads()
    {
        for (int i = 0; i < ShapesIndex.Length; i++)
        {
            EnemyHeads[ShapesIndex[i]].transform.localPosition = HeadPos[i].localPosition;
        }
    }

    private void InitializeEnemyData()
    {
        EnemyData.enemySpeed = 1.5f;
        EnemyData.enemyHealth = 3;
        EnemyData.enemydamage = 1;
    }

    public override void MoveToPlayer()
    {
        base.MoveToPlayer();
    }
    public override void Hit(int weapon)
    {
        if (weapon == ShapesIndex[currentShapeIndex])
        {
            currentShapeIndex++;
            EnemyData.enemyHealth--;

            if (EnemyData.enemyHealth <= 0){
                Death();
                HitParticle.Play();
            }
                

            UpdateShapeHead();

            Debug.Log($"현재 모양{currentShapeIndex}");
        }
        else
        {
            EnemyData.enemyHealth= 3;
            currentShapeIndex = 0;
            UpdateShapeHead();
        }
    }

    private void UpdateShapeHead()
    {
        for (int i = 0; i < EnemyHeads.Length; i++)
        {
            if (i < currentShapeIndex)
                EnemyHeads[ShapesIndex[i]].gameObject.SetActive(false);
            else
                EnemyHeads[ShapesIndex[i]].gameObject.SetActive(true);
            
        }
    }
}
