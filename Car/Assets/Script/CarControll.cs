using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarControll : MonoBehaviour
{
    private Rigidbody2D rigid;

    public WheelJoint2D wheelFront;
    public WheelJoint2D wheelBack;
    JointMotor2D jMortor;

    public bool FRGear = true;

    public float carSpeed = 200f;
    float spd;

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
    }

    public void PedalUp()
    {
        wheelFront.useMotor = false;
        wheelBack.useMotor = false;
        jMortor.motorSpeed = 0f;
        jMortor.maxMotorTorque = 5f;

        wheelFront.motor = jMortor;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid.AddForce(new Vector3(10,0,0), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Land"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
