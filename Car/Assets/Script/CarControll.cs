using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    private Rigidbody2D rigid;

    public WheelJoint2D wheelFront;
    public WheelJoint2D wheelBack;
    JointMotor2D jMortor;

    private bool FRGear = true;
    private bool Rotatable = true;
    public bool RotateDown;

    public float carSpeed = 200f;
    float spd;

    public GameObject Camera;
    public GameObject SpawnPoint;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spd = carSpeed;
    }

    public void PedalDown()
    {
        if (FRGear)
        {
            spd = carSpeed;
        }
        else
        {
            spd = -carSpeed;
        }

        wheelFront.useMotor = true;
        wheelBack.useMotor = true;
        jMortor.motorSpeed = spd;
        jMortor.maxMotorTorque = 10000f;

        wheelFront.motor = jMortor;
        wheelBack.motor = jMortor;

        RotateDown = true;
    }

    public void PedalUp()
    {
        wheelFront.useMotor = false;
        wheelBack.useMotor = false;
        jMortor.motorSpeed = 0f;
        jMortor.maxMotorTorque = 5f;

        wheelFront.motor = jMortor;

        RotateDown = false;
    }

    public void CarBreak()
    {
        wheelFront.useMotor = true;
        wheelBack.useMotor = true;
        jMortor.motorSpeed = 0f;
        jMortor.maxMotorTorque = 50f;

        wheelFront.motor = jMortor;
        wheelBack.motor = jMortor;
    }
    
    public void GearSetup()
    {
        if (FRGear)
        {
            FRGear = false;
        }
        else
        {
            FRGear = true;
        }
    }

    public void Rotate()
    {
        if (Rotatable && RotateDown)
        {
            transform.Rotate(0, 0, Time.deltaTime * -70);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid.AddForce(new Vector3(10,-6,0), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0,0, Time.deltaTime * -70);
        }
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Land"))
        {
            Rotatable = false;
        }

        if (collision.CompareTag("SpeedUp"))
        {
            InvokeRepeating("RepeatSomething", 1, 1);
        }

        if (collision.CompareTag("Moving"))
        {
            transform.position = SpawnPoint.transform.position;
            Camera.transform.position = SpawnPoint.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Land"))
        {
            Rotatable = true;
        }

        if (collision.CompareTag("SpeedUp"))
        {
            CancelInvoke("RepeatSomething");
        }
    }

    void RepeatSomething()
    {
        rigid.AddForce(new Vector3(10, -6, 0), ForceMode2D.Impulse);
    }

}
