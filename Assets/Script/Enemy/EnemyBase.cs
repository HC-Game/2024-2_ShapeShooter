using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyShapes { Triangle, Square, Pentagon, Heavy, Mini };
public abstract class EnemyBase : MonoBehaviour
{  
    public EnemyData enemyData;
    public Rigidbody rb;
    public abstract void init();
    public virtual void MoveToPlayer()
    {
        Vector3 dir = GameManager.Instance.player.position - rb.position;
        rb.MovePosition(rb.position + dir.normalized * enemyData.enemySpeed * Time.fixedDeltaTime);
        rb.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
    }
    public virtual void Hit(int weapon)
    {
        Debug.Log("hit");
        if (weapon == enemyData.CurrentEnemyShape)
        {
            enemyData.enemyHealth -= 1;
            Debug.Log(enemyData.enemyHealth);
        }

        if(enemyData.enemyHealth <= 0)
        {
            Death();
            Debug.Log(123);
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


