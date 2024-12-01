using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] TextMeshPro a; 

    private void OnEnable()
    {
        enemyBase.init();
    }
    private void FixedUpdate()
    {
        a.text =  $"{enemyBase.EnemyData.CurrentEnemyShape}";
        
        enemyBase.MoveToPlayer();
    }
}
