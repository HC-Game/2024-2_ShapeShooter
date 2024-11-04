using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquEnemy : EnemyBase
{
   
    public override void init()
    {
        base.init();
        enemyData.enemyHealth = 1;
        enemyData.CurrentEnemyShape = 1;
        enemyData.enemydamage = 1;
        
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
