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

    public void Level01()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level02()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level03()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level04()
    {
        SceneManager.LoadScene("Level4");
    }

}
