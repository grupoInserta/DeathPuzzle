using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
    public Transform Objetivo;
    private bool persiguiendo = false;
    private NavMeshAgent agente;

    // public Vector3 perseguirObjetivo;



    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

    }
    public void DetenerNavMeshAgent()
    {
        persiguiendo = false;
    }

    public void ActivarNavMeshAgent()
    {
        persiguiendo = true;
    }

    // Update is called once per frame
    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        if (persiguiendo)
        {
            agente.destination = Objetivo.position;

        }

    }

    public bool HemosLlegado()
    {
        //Debug.Log(agente.remainingDistance);
        // parece que el valor de agente.stoppingDistance se determina en el slot del NavMesh llamado de la misma forma.
        return agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending;
        /*remainingDistance es la distancia que falta para llegar al punto de destino y
        pertenece a la API de Unity como las siguientes */
        //stoppingDistance es la distancia que tenemos definida para detenernos
        //pathPending significa que no queda mas camino pendiente
    }
}


