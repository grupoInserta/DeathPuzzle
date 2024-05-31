using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscenas : MonoBehaviour
{

    [SerializeField]
    public string escena;
    public void CargarEscena()
    {
        SceneManager.LoadScene(escena);
        Debug.Log("Escena cargada)");
    }

    public void CargarEscenaNombre(string txt)
    {
        SceneManager.LoadScene(txt);
        Debug.Log("Escena cargada)");
    }
    public void Salir()
    {
        Debug.Log("Adios");
        Application.Quit();

    }
}
