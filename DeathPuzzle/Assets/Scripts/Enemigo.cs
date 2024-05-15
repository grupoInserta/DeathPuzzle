using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Path ScriptPath;
    public bool detectadoJugador = false;
    private MaquinaDeEstados maquinaDeEstados;


    // Start is called before the first frame update
    void Start()
    {
        ScriptPath = gameObject.GetComponent("Path") as Path;// del propio enemigo
        maquinaDeEstados = gameObject.GetComponent("MaquinaDeEstados") as MaquinaDeEstados;
        ScriptPath.parar();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered collision with " + other.gameObject.name);
        detectadoJugador = true;
        maquinaDeEstados.alertar();
        ScriptPath.parar();//el Path del enemigo
        // se para la patrulla 
    }


    private void OnTriggerExit(Collider other)
    {
        detectadoJugador = false;
        maquinaDeEstados.dejarEstadoAlerta();
        ScriptPath.andar();
    }



}
