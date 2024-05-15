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
    private float playerSize = 2f;
    private Vector3 moveDir;
    // [SerializeField]
    private Transform cameratransform;
    // Start is called before the first frame update
    void Start()
    {
         cameratransform = Camera.main.transform;   


    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 inputVector = input.normalized;
  
        moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float rotation = Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg + cameratransform.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smoothRotationTime);
      
        float targetSpeed = MoveSpeed * moveDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, 0.12f);
        bool canMove = ! Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), playerSize);     
        
        if (canMove)
        {
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }      

    }
}
