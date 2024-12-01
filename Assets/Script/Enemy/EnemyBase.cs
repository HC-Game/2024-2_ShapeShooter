using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyShapes { Triangle, Square, Pentagon, Heavy, Mini };
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;
    [SerializeField] EnemyData enemyData;
    public EnemyData EnemyData { get => enemyData; }
    [SerializeField] Rigidbody rb;

    bool isDead;

    public virtual void init() {
        EnemyData.enemySpeed = 2.4f;
        isDead = false;
        enemyAnimator.SetBool("IsDead", isDead);
        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
      
    }
    public virtual void MoveToPlayer()
    {
        if (isDead) return;
        Vector3 dir = GameManager.Instance.player.position - rb.position;
        rb.MovePosition(rb.position + dir.normalized * EnemyData.enemySpeed * Time.fixedDeltaTime);
        rb.rotation = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
    }
    public virtual void Hit(int weapon)
    {
        if (weapon == EnemyData.CurrentEnemyShape)
        {
            Death();
        }

    }
    public void Death()
    {
        StartCoroutine(DeadRoutine());
    }
    IEnumerator DeadRoutine()
    {
        isDead = true;
        enemyAnimator.SetBool("IsDead", isDead);

        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(2f);

        // 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }
    public bool GetDead()
    {
        return isDead;
    }
    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);    // 한 객체에 한번만
    }
}


