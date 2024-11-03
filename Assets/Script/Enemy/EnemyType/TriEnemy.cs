using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriEnemy : EnemyBase
{
    public override void init()
    {
     
   
        enemyData.enemyHealth = 1;
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
        base.Hit(weapon);
    }

}
