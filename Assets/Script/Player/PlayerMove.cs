using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector3 dir;
    CharacterController cc;

    public AudioClip footstep;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cc.isGrounded)
        {
            dir.y += Physics.gravity.y * Time.fixedDeltaTime;
        }
        cc.Move(dir * Time.deltaTime);
    }

    void FootStep()
    {
        AudioSource.PlayClipAtPoint(footstep, Camera.main.transform.position);
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveDir = value.Get<Vector2>();
        dir = new Vector3(moveDir.x, 0, moveDir.y) * speed;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg, 0);
        }
    }

    void OnJump()
    {
        Debug.Log("a");
        if (cc.isGrounded) // 캐릭터가 지면에 있는 경우에만 점프 허용
        {
            dir.y = 7.5f;
        }
    }
}
