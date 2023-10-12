using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    //Panel oculto
    public GameObject menuPausa;

    //Variable que nos dice si el juego est� pausado o no
    public bool juegoPausado = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Activaci�n por medio del teclado
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Condici�n que revisa si el juego est� o no en pausa
            if (juegoPausado)
            {
                //Juego activo
                Debug.Log("El juego est� activo");
                ContinuarJuego();
            }
            else
            {
                //Juego pausado
                Debug.Log("El juego est� pausado");
                PausaJuego();
            }
        }
    }

    //Funci�n de pausa
    public void PausaJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0; //Pausar el juego
        menuPausa.SetActive(true);
    }

    //Funci�n de reanudar el juego
    public void ContinuarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1;
        menuPausa.SetActive(false);
    }

    public void SalirdelJuego()
    {
        Application.Quit(); //Salir del juego (Solamente en compilaciones)
    }
}
