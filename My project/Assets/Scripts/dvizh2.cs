using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dvizh2 : MonoBehaviour
{
    [Header("Dashing")]

    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRigh = true;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] public float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.6f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;  

    private float dashingCooldown = 1f;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public TrailRenderer _TrailRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        _TrailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        var dashInput = Input.GetKeyDown(KeyCode.LeftShift);

        if(dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _TrailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if(_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }
        }

        if (_isDashing)
        {
            rb.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }

        StartCoroutine(StopDashing());



//        jumping();

        Flip();


    }

/*    private void jumping()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.05f); 
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

   }
*/
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRigh && horizontal < 0f || !isFacingRigh && horizontal > 0f);
        {
            isFacingRigh = !isFacingRigh;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _TrailRenderer.emitting = false;
        _isDashing = false;
    }

 /*   private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale =originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
*/    
}

 
