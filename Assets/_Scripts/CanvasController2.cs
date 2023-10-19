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

    public void PlayGame03()
    {
        SceneManager.LoadScene("Level3");
    }

    public void PlayGame04()
    {
        SceneManager.LoadScene("Level4");
    }
    public void SalirdelJuego()
    {
        Application.Quit(); //Salir del juego (Solamente en compilaciones)
    }
}
