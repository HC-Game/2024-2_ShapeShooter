using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyShapes { Null = - 1,Triangle, Cube, Pentagon, max };
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] Material HitMaterial;
    
    [SerializeField] ParticleSystem HitParticle;
    [SerializeField] Animator enemyAnimator;
    [SerializeField] EnemyData enemyData;
    public EnemyData EnemyData { get => enemyData; }
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject[] EnemyHeads;
    bool isDead;

    public virtual void init() {
       
        EnemyData.enemyHealth = 1;
        EnemyData.enemydamage = 1;
        EnemyData.enemySpeed = 2.4f;
        isDead = false;
        EnemyData.currentEnemyShape = Random.Range(0,3);
        SetHead();
        enemyAnimator.SetBool("IsDead", isDead);
        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
      
    }

    void SetHead(){
        for(int i=0; i<EnemyHeads.Length;i++){
            EnemyHeads[i].SetActive(false);
        }
        EnemyHeads[EnemyData.currentEnemyShape].SetActive(true);
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
        if (weapon == EnemyData.currentEnemyShape)
        {
             EnemyHeads[EnemyData.currentEnemyShape].SetActive(false);
            HitParticle.Play();
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

    
        gameObject.SetActive(false);
    }
    public bool GetDead()
    {
        return isDead;
    }
    void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);    
    }
}


