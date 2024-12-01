using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{

    [Header("-----Player Property-----")]
    [SerializeField] bool isDamaged;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float jumpForce = 5;

    int _health;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;

            if (_health < 1)
            {
                _health = 0;
                Death();
            }
            PlayerUI.instance.HPMinus1(_health);
        }
    }

    [Header("-----Move Component-----")]
    [SerializeField] Transform foot;
    [SerializeField] LayerMask ground;
    Rigidbody rb;
    Vector3 move = Vector3.zero;
    Vector2 rotate;
    Transform cameraTransform;
    float originSpeed;
    private Vector3 boxSize;
    bool isGround=true;
    
    [Header("-----Camera Property-----")]
    [SerializeField] float cameraPitch = 0f;    // ī�޶��� ���� ȸ�� ���� (��/�Ʒ�)
    [SerializeField] float maxCameraAngle = 80f; // ī�޶��� �ִ� ȸ�� ����

    [Header("-----Ammo Property-----")]
    int curruntAmmo = 0;


    [Header("-----Shoot Property-----")]
    [SerializeField] float fireRange = 10f; // ��Ÿ�
    [SerializeField] GameObject ShootDelayBarUI;
    [SerializeField] Slider ShootDelayBar;
    [SerializeField] ParticleSystem shotParticle;

    bool CanShoot = true;
    WaitForSeconds ShootDelay = new WaitForSeconds(0.05f);

    #region Unity Logic
    private void Start()
    {
        
        PlayerUI.instance.Choose(curruntAmmo);
        _health = PlayerUI.instance.GetMaxHealth();
        cameraTransform = GameManager.Instance.playerCam.transform;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        ShootDelayBarUI.SetActive(false);
        originSpeed = speed;

        boxSize = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
    }

    void LateUpdate()
    {
        CameraSet();

        
    }

    void FixedUpdate()
    {

        Moving();
    }
    private void OnCollisionStay(Collision collision)
    {
       if (collision.gameObject.CompareTag("Enemy") && isDamaged == false)
        {
            Health--;
            isDamaged = true;
            StartCoroutine(DamagedRoutine());
        }
    }

    IEnumerator DamagedRoutine()
    {
        yield return new WaitForSeconds(1f);
        isDamaged = false;
    }
    #endregion
    #region Player Input
    private void OnMove(InputValue value)
    {
        Vector2 inputMove = value.Get<Vector2>();

        // �̵� ���� ��� (Forward ����� Right ������ ����)
        move = new Vector3(inputMove.x, 0, inputMove.y);
    }

    private void OnLook(InputValue value)
    {
        rotate = value.Get<Vector2>();
    }

    private void OnFire()
    {
        if (!CanShoot) { return; }
        StartCoroutine(CheckCanShoot());
        shotParticle.Play();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, fireRange))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyBase>().Hit(curruntAmmo);
            }
        }
    }
    IEnumerator CheckCanShoot()
    {
        ShootDelayBarUI.SetActive(true);
        ShootDelayBar.value = 0;
        CanShoot = false;

        for (float i = 1; i <= 16; i++)
        {
            ShootDelayBar.value = i / 16;
            yield return ShootDelay;
        }
        ShootDelayBarUI.SetActive(false);
        CanShoot = true;

    }

    public void OnJump()
    {
        if (!isGround) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGround = false;
        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        while (!isGround)
        {
            yield return new WaitForSeconds(0.1f);
            if (Physics.CheckBox(foot.position, boxSize / 2, Quaternion.identity, ground))
            {
                isGround = true;
                Debug.Log("isGround = true");
            }
        }
    }
    private void OnNumber()
    {
        // �Էµ� ���� Ű�� ó��
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            curruntAmmo = 0;
            PlayerUI.instance.Choose(curruntAmmo);
       
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            curruntAmmo = 1;
            PlayerUI.instance.Choose(curruntAmmo);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            curruntAmmo = 2;
            PlayerUI.instance.Choose(curruntAmmo);
        }
    }
    private void OnSprint()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            speed = originSpeed * 2f;
        }
        if (Keyboard.current.shiftKey.wasReleasedThisFrame)
        {
            speed = originSpeed;

        }

        //if (move != Vector3.zero && Keyboard.current.shiftKey.wasPressedThisFrame)
        //{
        //    // �̵� ó��: ȸ���� ������ �������� �̵� ���͸� ���
        //    Vector3 moveDirection = rb.rotation * move.normalized;
        //    rb.AddForce(moveDirection*3f,ForceMode.Impulse);
        //}
    }
    #endregion
    #region Move Logic
    private void Moving()
    {
        if (move != Vector3.zero)
        {
            // �̵� ó�� (ȸ���� ������ �������� �̵� ���͸� ���)
            Vector3 moveDirection = rb.rotation * move.normalized;
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }

    private void CameraSet()
    {
        // ȸ�� ó�� (ĳ���� �¿� ȸ��)
        if (rotate.x != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0, rotate.x * rotateSpeed * Time.deltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // ī�޶� ȸ�� ó�� (��/�Ʒ� ȸ��)
        if (rotate.y != 0)
        {
            cameraPitch -= rotate.y * rotateSpeed * Time.deltaTime; 
            cameraPitch = Mathf.Clamp(cameraPitch, -maxCameraAngle, maxCameraAngle); 
            cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
        }
    }
    #endregion
    
    #region Game Logic
    void Death()
    {
        Debug.Log("death");
    }
    #endregion
}
