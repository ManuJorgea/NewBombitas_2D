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
}
