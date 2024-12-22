using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum EnemyShapes { Null = -1, Triangle, Cube, Pentagon, max };
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] Material HitMaterial;

    [SerializeField] protected ParticleSystem HitParticle;
    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected EnemyData enemyData;
    protected EnemyData EnemyData { get => enemyData; }
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected GameObject[] EnemyHeads;
    Vector3 originScale;
    protected bool isDead;

    void Awake() {
        originScale = transform.localScale;
    }
    public virtual void init()
    {
        EnemyData.enemyHealth = 1;
        EnemyData.enemydamage = 1;
        EnemyData.enemySpeed = 2.4f;
        
        isDead = false;
        enemyAnimator.SetBool("IsDead", isDead);

        rb.isKinematic = false;
        GetComponent<Collider>().enabled = true;
        SetHead();
        ScaleSet();
    }
    public void ScaleSet(){
        var scaleFactor =  Random.Range(0.3f,2);
        transform.localScale = originScale * scaleFactor;
    }
    void SetHead()
    {
        EnemyData.currentEnemyShape = Random.Range(0, 3);
        for (int i = 0; i < EnemyHeads.Length; i++)
        {
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
        AudioManager.Instance.PlaySFX("kill");
        StartCoroutine(DeadRoutine());
        GameManager.Instance.KillUp();
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


