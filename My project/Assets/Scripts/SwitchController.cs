using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{ 
    public GameObject[] ollPlayers;
    private int randomController;
    
 
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            randomController = Random.Range(0, ollPlayers.Length);
            randomSpawn();
            
           
        }       
        
    void randomSpawn()
        {
            Instantiate(ollPlayers[randomController], transform.position, Quaternion.identity);   
        }
    }
}
