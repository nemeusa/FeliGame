using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float Speed = 3f;
    private Rigidbody2D PlayerRb;
    private Vector2 MoveInput;
    public bool DontMove = false;
    [SerializeField] Vector2 ReboundSpeed;

    [SerializeField] Animator PlayerAnimator;


    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        //PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        MoveInput = new Vector2(moveX, moveY).normalized;

        //PlayerAnimator.SetFloat("Horizontal", moveX);
        //PlayerAnimator.SetFloat("Vertical", moveY);
        PlayerAnimator.SetFloat("Speed", MoveInput.sqrMagnitude);


        //if (Input.GetKey(KeyCode.A))
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }

        //else if (Input.GetKey(KeyCode.D))
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    private void FixedUpdate()
    {
        if (!DontMove)
        {
            PlayerRb.MovePosition(PlayerRb.position + MoveInput * Speed * Time.fixedDeltaTime);
        }
        
    }

    public void Reboud (Vector2 HitPoint)
    {
       PlayerRb.velocity = new Vector2(ReboundSpeed.x * HitPoint.x, ReboundSpeed.y);
    }
}
