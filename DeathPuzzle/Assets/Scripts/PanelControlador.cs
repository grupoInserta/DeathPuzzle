using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelControlador : MonoBehaviour
{
    [SerializeField] private GameObject[] Objetos;
    [SerializeField] public GameObject Jugador;
    [SerializeField] public GameObject Enemigo;
    private PlayerController playerControllerScript;
    private TextMeshProUGUI textObjetos;
    private int numObjetos;
    private CargaEscenas escena;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = Jugador.GetComponent<PlayerController>();

        GameObject NumObjetos;
        NumObjetos = transform.GetChild(1).gameObject;
        textObjetos = NumObjetos.GetComponent<TextMeshProUGUI>();
        escena = Jugador.GetComponent<CargaEscenas>();
        numObjetos = Objetos.Length;
    }

    // Update is called once per frame
    void Update()
    {
        int objetosRestantes = numObjetos -  playerControllerScript.obtenerObjetosRecogidos();
        textObjetos.text = "Num objetos restantes: "+ objetosRestantes;
        if (objetosRestantes == 0)
        {
            objetosRestantes = -1;
            playerControllerScript.EstablecerNumObjetosFinal();
            textObjetos.text = "Nivel completado!!!";
        }
        float dist = Vector3.Distance(Jugador.transform.position, Enemigo.transform.position);
        Debug.Log(dist);
        if(dist < 1f)
        {
            Debug.Log("Partida perdida!!!");
            escena.CargarEscenaNombre("Derrota");
        }

      
    }
}
