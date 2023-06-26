using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Take : MonoBehaviour, IInteractable
{
    public GameObject WhoTakes;
    public float distance = 15f;

    public bool isTaking = false;

    private Rigidbody rb;
    private Camera piCam;
    

    void Start()
    {
        piCam =  WhoTakes.GetComponent<PlayerInteraction>().cam;

    }
    void Update()
    {
        if (WhoTakes.GetComponent<CameraScript>().gisdown())
        {
            Drop();
        }
    }
    public void Interact()
    {
        isTaking = !isTaking;
        rb = GetComponent<Rigidbody>();
        GetComponent<BoxCollider>().enabled = false;
        rb.useGravity = false;
        transform.SetParent(WhoTakes.transform);
        transform.SetLocalPositionAndRotation(new Vector3(0.34f, -0.5f, 0.909f), Quaternion.Euler(WhoTakes.transform.rotation.x, 180f, 0f));
    }

    public void Drop()
    {
        if (isTaking)
        {
            transform.SetParent(null);
            rb = GetComponent<Rigidbody>();
            GetComponent<BoxCollider>().enabled = true;
            rb.useGravity = true;
            GetComponent<Gun>().fpsCam = null;
            isTaking = !isTaking;
        }
    }


    private double[] Yconv(float yDegree)
    {
        double[] ans = new double[2];
        ans[1] = Math.Cos(yDegree);
        ans[0] = Math.Sin(yDegree);
        return ans;
    }


    public string GetDiscription()
    {
        if (isTaking) return "Взять нельзя";
        return "Можно взять"; 
    }

    
}
