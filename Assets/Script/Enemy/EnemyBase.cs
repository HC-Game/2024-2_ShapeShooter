using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyShapes { Triangle, Square, Pentagon, Heavy, Mini };
public abstract class EnemyBase : MonoBehaviour
{  
    public EnemyData enemyData;
    public Rigidbody rb;
    public virtual void init() {
        enemyData.enemySpeed = 2.4f;
    }
    public virtual void MoveToPlayer()
    {
        Vector3 dir = GameManager.Instance.player.position - rb.position;
        rb.MovePosition(rb.position + dir.normalized * enemyData.enemySpeed * Time.fixedDeltaTime);
        rb.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
    }
    public virtual void Hit(int weapon)
    {
        if (weapon == enemyData.CurrentEnemyShape)
        {
            Death();
        }

    }

    public void Death()
    {
        
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);    // 한 객체에 한번만
    }
}


