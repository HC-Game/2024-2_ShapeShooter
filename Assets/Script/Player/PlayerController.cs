using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{

    //Move Component
    Rigidbody rb;
    Vector3 move = Vector3.zero;
    Vector2 rotate;
    Transform cameraTransform;

    //Move Property
    public float speed = 5f;
    public float rotateSpeed = 10f;

    // ī�޶��� Transform
    public float cameraPitch = 0f;    // ī�޶��� ���� ȸ�� ���� (��/�Ʒ�)
    public float maxCameraAngle = 80f; // ī�޶��� �ִ� ȸ�� ����

    //Ammo
    PlayerUI PlayerUI;
    int curruntAmmo = 0;
    //Shoot Property
    bool CanShoot = true;
    WaitForSeconds ShootDelay = new WaitForSeconds(1f);
    public float fireRange = 10f; // ��Ÿ�

    void Start()
    {
        PlayerUI = GetComponent<PlayerUI>();
        PlayerUI.Choose(curruntAmmo);

        cameraTransform = GameManager.Instance.playerCam.transform;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CameraSet();
    }
    void FixedUpdate()
    {
   
        Moving();
    }

    private void Moving()
    {
        if (move != Vector3.zero)
        {
            // �̵� ó��: ȸ���� ������ �������� �̵� ���͸� ���
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
            cameraPitch -= rotate.y * rotateSpeed * Time.deltaTime; // ���콺 y���� �ݴ�� ����
            cameraPitch = Mathf.Clamp(cameraPitch, -maxCameraAngle, maxCameraAngle); // ȸ�� ���� ����
            cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
        }
    }

    #region �÷��̾� ��ǲ
    private void OnMove(InputValue value)
    {
        Vector2 inputMove = value.Get<Vector2>();

        // �̵� ���� ���: Forward ����� Right ������ ����
        move = new Vector3(inputMove.x, 0, inputMove.y);
    }

    private void OnLook(InputValue value)
    {
        rotate = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (CanShoot&&Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, fireRange))
        {
            StartCoroutine(CheckCanShoot());
            Debug.Log("shoot");
            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyBase>().Hit(curruntAmmo);
            }
        }
    }

    private void OnNumber()
    {
        // �Էµ� ���� Ű�� ó��
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            curruntAmmo = 0;
            PlayerUI.Choose(curruntAmmo);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            curruntAmmo = 1;
            PlayerUI.Choose(curruntAmmo);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            curruntAmmo = 2;
            PlayerUI.Choose(curruntAmmo);
        }
    }
    #endregion
    IEnumerator CheckCanShoot()
    {
        CanShoot = false;
        Debug.Log("cantShoot");
        yield return ShootDelay;
        CanShoot = true;
        Debug.Log("canShoot");
    }
}
