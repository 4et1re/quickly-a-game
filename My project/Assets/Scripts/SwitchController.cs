using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{ 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    private int randomController;
    
    
 
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        randomController = Random.Range(0, 3);

        if (Input.GetKeyDown(KeyCode.P) && randomController == 1)
        {
            Instantiate(Player1, transform.position, Quaternion.identity);   
            Destroy(Player2);
            Destroy(Player3);
           
        }
         if (Input.GetKeyDown(KeyCode.P) && randomController == 2)
        {
            Instantiate(Player2, transform.position, Quaternion.identity);   
            Destroy(Player1);
            Destroy(Player3);
           
        }       
         if (Input.GetKeyDown(KeyCode.P) && randomController == 3)
        {
            Instantiate(Player3, transform.position, Quaternion.identity);   
            Destroy(Player2);
            Destroy(Player1);
           
        }       
    
    }
}
