using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
 
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void FixedUpdate()
    {
        Vector3 dir = GameManager.Instance.player.position - enemyRb.position;
        enemyRb.MovePosition(enemyRb.position + dir.normalized * EnemySpeed*Time.fixedDeltaTime);
    }
}
