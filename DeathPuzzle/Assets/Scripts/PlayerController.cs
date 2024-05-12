using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float MoveSpeed = 5f;
    [SerializeField]
    public float smoothRotationTime = 0.12f;
    private float currentVelocity;
    private float currentSpeed;
    private float speedVelocity;
    [SerializeField]
    private Transform cameratransform;
    // Start is called before the first frame update
    void Start()
    {
        // cameratransform = Camera.main.transform;
        Debug.Log("hola");
    }

    // Update is called once per frame
    void Update()
    {


    Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input.normalized;
        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameratransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
        }
        float targetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.12f);
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

    }
}
