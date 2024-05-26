using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : Estado
{
    //VER JUGADOR
    private MaquinaDeEstados maquinaDeEstados;
    private ControladorVision controladorVision;
    private ControladorNavMesh controladorNavMesh;
    /*
     El codigo de arriba y el trozo final del update habr�a que llevarlo a un script a parte llamado Mirar
    y en el se suprimir�a el update y se sustituir�a por una funci�n de actualizaci�n desde este mismo scripr que se llame desde este
    update.
    Esto servir�a para implementarlo en el estado Alerta tambi�n
    Lo obtendr�amos con el metodo addComponent..
      */
    //FIN VER JUGADOR
    private Path EnemigoScriptPath;
    private Transform puntoObjetivo;
    private float velocidadGiro = .02f;
    private Quaternion rotFinal;
    private Vector3 direccion;

    private void Start()
    {
        EnemigoScriptPath = Enemigo.GetComponent("Path") as Path;
        EnemigoScriptPath.andar();// es Path
        //VER JUGADOR
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorVision = transform.GetChild(0).GetComponent<ControladorVision>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        //FIN VER JUGADOR        
    }

    private void OnEnable()
    {
        EnemigoScriptPath.andar();
    }


    void Update()
    {

        puntoObjetivo = EnemigoScriptPath.PuntoActivo;
        direccion = (puntoObjetivo.position - transform.position).normalized;
        rotFinal = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotFinal, velocidadGiro);
        //
        RaycastHit hit;//VER JUGADOR
        if (controladorVision.puedeVerAlJugador(out hit))//Si ve al jugador se activa el estado de persecuci�n
        {
            controladorNavMesh.Objetivo = hit.transform;//Devuelve la posici�n del jugador
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.estadoPersecucion);
            return;//Volvemos sin seguir debugando el m�todo
        }

    }

}