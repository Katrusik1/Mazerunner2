using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] spawningPoints;
    private void OnTriggerEnter(Collider other)
    {
        spawn();
    }

    private void spawn()
    {
        for(int i = 0; i < spawningPoints.Length; i++)
        {
            //
        }
    }
}
