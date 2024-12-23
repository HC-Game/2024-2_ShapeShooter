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
        enemyData.enemyHealth = 3;
        currentShapeIndex = 0;
        isDead = false;
        enemyAnimator.SetBool("IsDead", isDead);
        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
        InitializeEnemyShape();
        SetEnemyHeads();
        UpdateShapeHead();
        
        base.ScaleSet();
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

        enemyData.enemySpeed = 1.5f;

        enemyData.enemydamage = 1;
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
            enemyData.enemyHealth--;
            UpdateShapeHead();
            HitParticle.Play();
            if (enemyData.enemyHealth <= 0){
                Death();
                return;
            }
            AudioManager.Instance.PlaySFX("hit");
            enemyAnimator.SetTrigger("Hit");
        }
        else
        {
             AudioManager.Instance.PlaySFX("falseHit");
            enemyData.enemyHealth= 3;
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
