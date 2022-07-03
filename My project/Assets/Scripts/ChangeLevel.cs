using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    

    // Start is called before the first frame update
    public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    void  Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
