using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] spawningPoints;
    private bool canspawn = true;
    private void OnTriggerEnter(Collider other)
    {
        if (canspawn)
        { 
            spawn();
            canspawn = false;
        }
    }

    private void spawn()
    {
        Debug.Log(enemy.Length);
        Debug.Log(spawningPoints.Length);
        for(int i = 0; i < spawningPoints.Length;)
        {
            GameObject newenemy = Instantiate(enemy[Random.Range(0, enemy.Length-1)]);
            newenemy.transform.position = spawningPoints[i].transform.position + new Vector3(0, 0.5f,0);
            i += 1;
        }
    }
}
