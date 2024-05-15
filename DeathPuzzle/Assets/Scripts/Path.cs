using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Puntos;
    [SerializeField] float velocidad;
    public Transform PuntoActivo;
    public bool parado;
    private int IndicePuntos;
    void Start()
    {
        transform.position = Puntos[0].transform.position;
        IndicePuntos = 0;
        PuntoActivo = Puntos[1];
    }

    public void parar()
    {
        this.enabled = false;
    }

    public void andar()
    {
        this.enabled = true;
        parado = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (parado)
        {
            return;
        }
        //Debug.Log(Puntos.Length);

        transform.position = Vector3.MoveTowards(transform.position, Puntos[IndicePuntos].transform.position, velocidad * Time.deltaTime);
        // Debug.Log(transform.position.z + "--" + Puntos[IndicePuntos].transform.position.z);
        if (transform.position == Puntos[IndicePuntos].transform.position)
        {
            IndicePuntos++; // sigue a atro pundo               
        }
        if (IndicePuntos == Puntos.Length)
        {
            IndicePuntos = 0;
        }
        PuntoActivo = Puntos[IndicePuntos];

    }

}
