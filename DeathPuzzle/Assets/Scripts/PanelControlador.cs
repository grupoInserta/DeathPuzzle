using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelControlador : MonoBehaviour
{
    [SerializeField] private GameObject[] Objetos;
    [SerializeField] public GameObject Jugador;
    private PlayerController playerControllerScript;
    private TextMeshProUGUI textObjetos;
    private int numObjetos;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = Jugador.GetComponent<PlayerController>();
        GameObject NumObjetos;
        NumObjetos = transform.GetChild(1).gameObject;
        textObjetos = NumObjetos.GetComponent<TextMeshProUGUI>();
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
    }
}
