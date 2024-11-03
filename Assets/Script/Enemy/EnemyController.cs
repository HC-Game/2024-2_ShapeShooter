using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public EnemyBase enemyBase;
    public TextMeshPro a; 
    private void Start()
    {
        enemyBase.init();
    }
    private void FixedUpdate()
    {
        a.text =  $"{enemyBase.enemyData.CurrentEnemyShape}";
        a.transform.position = new Vector3(transform.position.x,2,transform.position.z);
        enemyBase.MoveToPlayer();
    }
  

}
