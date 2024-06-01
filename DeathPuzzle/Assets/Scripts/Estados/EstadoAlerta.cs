
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
        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);//cómo voy a girar
        tiempoBuscando += Time.deltaTime;//se incrementa en tiempo real el tiempo que está en alerta
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPatrulla);//Volvemos al estado patrulla si no vemos al jugador en 4 segundos
            
            tiempoBuscando = 0;
            return;//No hace falta, es sólo por si escribiéramos más código debajo
        }

        RaycastHit hit;

        if (controladorVision.puedeVerAlJugador(out hit))//Si ve al jugador se activa el estado de persecución, si nomandamos un segundo parametro mirar al jugador es false
        {
            Debug.Log("jugador visto");
            controladorNavMesh.Objetivo = hit.transform;//Devuelve la posición del jugador
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPersecucion);
            return;//Volvemos sin seguir debugando el método
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