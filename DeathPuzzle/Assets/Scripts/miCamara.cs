using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miCamara : MonoBehaviour
{
    float RotationMin = -40f;
    float RotationMax = 80f;
    float smoothTime = 0.12f;

    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 4f;

    public Transform target;
    Vector3 targetRotation;
    Vector3 currentVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
        Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * 2f;
    }
}