using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dvizh3 : MonoBehaviour {

    public float MOVE_SPEED = 20f;
    public float dashAmount = 3f;
    public float dashTime = 3f;

    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] public GameObject PS;
    [SerializeField] public GameObject DashParticle;

    private Animator camAnim;
    
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private bool isDashButtonDown; 
    

   

    private void Awake() {
            
            rigidbody2D = GetComponent<Rigidbody2D>();
            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        }

    private void Update() {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) {
            moveY = +1f;
            Instantiate(PS, transform.position, Quaternion.identity);
        }
         else
        {
            moveDir = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveY = -1f;
            Instantiate(PS, transform.position, Quaternion.identity);
        }
         else
        {
            moveDir = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveX = -1f;
            Instantiate(PS, transform.position, Quaternion.identity);
        }
         else
        {
            moveDir = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX = +1f;
            Instantiate(PS, transform.position, Quaternion.identity);
        }
        else
        {
            moveDir = Vector3.zero;
        }

        moveDir = new Vector3(moveX, moveY).normalized;

            if (moveDir != Vector3.zero)
        {
        
          rigidbody2D.MoveRotation(Quaternion.LookRotation(moveDir));   
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space)) {
            isDashButtonDown = true;
        }

          if(Input.GetKey(KeyCode.O))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        rigidbody2D.velocity = moveDir * MOVE_SPEED;

        if (isDashButtonDown && moveDir != Vector3.zero ) 
        {
            StartCoroutine(Dash());
            camAnim.SetTrigger("Shake");
        
        }

      IEnumerator Dash()
        {
            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHit2d.collider != null) {
                dashPosition = raycastHit2d.point;
            }
                Instantiate(DashParticle, transform.position, Quaternion.identity);
            

            // Spawn visual effect
           
            rigidbody2D.MovePosition(dashPosition);

            

            isDashButtonDown = false;
            yield return new WaitForSeconds(dashTime);
        }
    }

}
