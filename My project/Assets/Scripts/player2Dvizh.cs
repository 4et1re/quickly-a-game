using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Dvizh : MonoBehaviour
{

    private Vector2 targetPos;
    public float Yincrement;

    public float speed; 
    public float maxHeight;
    public float minHeight;

    [SerializeField] public GameObject PS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
             Instantiate(PS, transform.position, Quaternion.identity);
          
        }
        else  if(Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
             Instantiate(PS, transform.position, Quaternion.identity);
            
        }


        
    }
}
