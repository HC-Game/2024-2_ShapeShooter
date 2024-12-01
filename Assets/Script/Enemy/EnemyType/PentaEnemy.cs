using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentaEnemy : EnemyBase
{
    public override void init()
    {
        base.init();
        EnemyData.enemyHealth = 1;
        EnemyData.CurrentEnemyShape = 2;
        EnemyData.enemydamage = 1;
      
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
