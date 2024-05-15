using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControladorVision : MonoBehaviour

{
    public float rangoVision = 20f;//La distancia a la que vamos a lanzar el rayo
    public Transform Ojos;//Desde d�nde lanzamos el rayo
    public Vector3 offset = new Vector3(0f, 1.80f, 0f);//La posici�n del jugador est� en y=0, por eso la subimos, para que ojos pueda ver en paralelo al suelo
    private ControladorNavMesh controladorNavMesh;

    void Start()
    {
        controladorNavMesh = transform.parent.GetComponent<ControladorNavMesh>();
        Ojos = this.gameObject.transform;
        //Debug.Log(Ojos.position);
    }


    public bool puedeVerAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = false)
    {
        Vector3 vectorDireccion;

        if (mirarHaciaElJugador)//En caso de estar en persecuci�n, necesitamos que siga al jugador en cualquier caso, no s�lo si lo ve
        {
            vectorDireccion = (controladorNavMesh.Objetivo.position + offset) - Ojos.position;
            //La direcci�n del rayo ser�a la resta de la posici�n del jugador - la posici�n del objeto ojos

        }
        else
        { // en caso de alerta y patrulla
            vectorDireccion = Ojos.forward;

            // forward es un vector en direccion z: new Vector3(0,0.1) del objeto!!
            // Vector3.forward es global   y transform.forward es locoal
        }

        vectorDireccion = Ojos.forward;
        return Physics.Raycast(Ojos.position, vectorDireccion, out hit, rangoVision) && hit.collider.CompareTag("Jugador");
        //(origen del rayo, la direcci�n del rayo, informaci�n de d�nde ha impactado, distancia m�xima && ha colisionado con el jugador)
    }
    /*
    public Transform Ojos;//Desde d�nde lanzamos el rayo
    public float rangoVision = 20f;//La distancia a la que vamos a lanzar el rayo
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);//La posici�n del jugador est� en y=0, por eso la subimos, para que ojos pueda ver en paralelo al suelo
    private ControladorNavMesh controladorNavMesh;
    RaycastHit devuelve informaci�n del impacto del rayo
    */
}


