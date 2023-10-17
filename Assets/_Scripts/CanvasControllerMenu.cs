using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControllerMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Interfaces_Menus");
    }

   /*
    public void SelectLevel()
    {
        SceneManager.LoadScene("Interfaces_Menus");
        gameObject.SetActive(false);
    }
   */
}
