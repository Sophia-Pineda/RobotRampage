using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
   public void Start()
   {
        SceneManager.LoadScene("Battle");
        
   }
    //2 
    public void Quit()
    {
        Application.Quit();

    }
    

}
