using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
  
   public void OnPlay(){
            SceneManager.LoadScene("Level1");
   }

       void Awake()
        {
            // To show cursor after First Person Controller
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
}
