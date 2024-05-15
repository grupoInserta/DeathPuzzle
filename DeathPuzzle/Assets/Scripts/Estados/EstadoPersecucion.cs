using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : Estado
{
    private ControladorNavMesh controladorNavMesh;
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorVision controladorVision;
    private Path scriptPath;
    // Start is called before the first frame update
    void Start()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = transform.GetChild(0).GetComponent<ControladorVision>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        scriptPath = GetComponent<Path>();
        perseguir();
    }

    public void perseguir()
    {
        controladorNavMesh.ActivarNavMeshAgent();
        scriptPath.parar();
    }

    public void dejarDePerseguir()
    {
        controladorNavMesh.DetenerNavMeshAgent();
        scriptPath.andar();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.puedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.alertar();
            return;
        }
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
        if (controladorNavMesh.HemosLlegado())
        {
            //Debug.Log("fin juego.");OK
        }

    }
}
