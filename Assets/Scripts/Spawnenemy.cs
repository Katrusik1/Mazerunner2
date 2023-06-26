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
        for(int i = 0; i < spawningPoints.Length; i++)
        {
            Debug.Log(enemy.Length);
            GameObject newenemy = Instantiate(enemy[Random.Range(0, enemy.Length)]);
            newenemy.transform.position = spawningPoints[i].transform.position;
        }
    }
}
