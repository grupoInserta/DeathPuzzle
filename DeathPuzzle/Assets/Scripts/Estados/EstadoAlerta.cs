
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EstadoAlerta : Estado
{
    public float velocidadGiroBusqueda = 120f;//grados por segundo
    public float duracionBusqueda = 8f;//unidades por segundo
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorVision controladorVision;
    private ControladorNavMesh controladorNavMesh;
    private float tiempoBuscando;

    void Start()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorVision = transform.GetChild(0).GetComponent<ControladorVision>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
    }

    void Update()
    {
        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);//c�mo voy a girar
        tiempoBuscando += Time.deltaTime;//se incrementa en tiempo real el tiempo que est� en alerta
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPatrulla);//Volvemos al estado patrulla si no vemos al jugador en 4 segundos
            
            tiempoBuscando = 0;
            return;//No hace falta, es s�lo por si escribi�ramos m�s c�digo debajo
        }

        RaycastHit hit;

        if (controladorVision.puedeVerAlJugador(out hit))//Si ve al jugador se activa el estado de persecuci�n, si nomandamos un segundo parametro mirar al jugador es false
        {
            Debug.Log("jugador visto");
            controladorNavMesh.Objetivo = hit.transform;//Devuelve la posici�n del jugador
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPersecucion);
            return;//Volvemos sin seguir debugando el m�todo
        }
    }
    /*
    void OnEnable()//Cuando se activa el estado de alerta, detenemos al enemigo
    {
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;//Hay que inicializar cada vez que entremos en estado de alerta
    }
 
    */
}