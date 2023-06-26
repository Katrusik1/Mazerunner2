using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 7f;
    public float jumpPower = 200f;
    public bool ground;
    public float sens = 200f;

    private Rigidbody rb;
    private CapsuleCollider collider;


    private void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            collider.height = 1f;
        }
        else
        {
            collider.height = 2f;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground") ground = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground") ground = false;
    }
}
