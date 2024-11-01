using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentaEnemy : EnemyBase
{
    public override void init()
    {
        enemyData.enemyShapes = EnemyShapes.Pentagon;
        enemyData.enemyHealth = 1;
        enemyData.CurrentEnemyShape = 2;
        enemyData.enemydamage = 1;
       enemyData.enemySpeed = 1f;
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
