using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float motor_force;
    public Rigidbody rb;

    public float speed;

    public float accelration = 5f;

    public WheelCollider front1;
    public WheelCollider front2;

    public Transform front_1;
    public Transform front_2;

    Vector3 rotationRight = new Vector3(0, 15, 0);
    Vector3 rotationLeft = new Vector3(0, -15, 0);

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            motor_force += Time.deltaTime * accelration;
            front1.motorTorque = motor_force;
            front2.motorTorque = motor_force;

        }

        else
        {
            if (front1.motorTorque > 0 && rb.velocity.z > 0)
            {
                motor_force -= Time.deltaTime * accelration * 100;
                front1.motorTorque = motor_force;
                front2.motorTorque = motor_force;

                front1.transform.Rotate(Vector3.forward * motor_force);
                front2.transform.Rotate(Vector3.forward * motor_force);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion delta_rotation_right = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(delta_rotation_right * rb.rotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion delta_rotation_left = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(delta_rotation_left * rb.rotation);
        }

    }
}


