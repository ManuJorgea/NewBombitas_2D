using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController2 : MonoBehaviour
{
    public void PlayGame01()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level2");
    }
}
