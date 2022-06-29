using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvizh : MonoBehaviour
{
    public float moveSpeed = 10f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    public Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float dir;
  //  public float direction;

    private float activeMoveSpeed;
    public float dashSpeed;
    private float dashingPower = 24f; 

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
         {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);   
         }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       moveVelocity.x = Input.GetAxisRaw("Horizontal");
       moveVelocity.y = Input.GetAxisRaw("Vertical");
    
       moveVelocity.Normalize();

       rb.velocity = moveVelocity * activeMoveSpeed;

//       if(Input.GetKeyDown(KeyCode.Space))
//       {
//           print("dash!");
//        
//        rb.velocity = moveVelocity * dashSpeed * Time.deltaTime;


//           if(dashCoolCounter <= 0 && dashCounter <= 0)
//         {
//              activeMoveSpeed = dashSpeed;
//               dashCounter = dashLength;
//           }
//       }

//       if (dashCounter > 0)
//       {
//           dashCounter -= Time.deltaTime;
//
//           if(dashCounter <= 0)
//           {
//              activeMoveSpeed = moveSpeed;
//               dashCoolCounter = dashCooldown;
//           }
//       }
//
//       if(dashCoolCounter > 0)
//       {
//           dashCoolCounter -= Time.deltaTime;
//       }
//        


        //  flip x if moving left
        //transform.GetChild(0).rotation = Quaternion.Euler(0f, (direction > 0 ? 0f : 180f), 0f);
//        }

    
    }
}

