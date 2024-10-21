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
        enemyRb.MovePosition(enemyRb.position + dir.normalized * enemySpeed * Time.fixedDeltaTime);
        enemyRb.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg, 0);
        
    }
}
