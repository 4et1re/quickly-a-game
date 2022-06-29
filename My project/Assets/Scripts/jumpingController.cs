using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    public float jumpForce;
    private float moveInput;

    public Transform feetPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rigidbody2D.velocity = Vector2.up * jumpForce; 
                jumpTimeCounter -= Time.deltaTime;
            }
            else   
            {
                isJumping = false;
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }


            
        }
    }
}
