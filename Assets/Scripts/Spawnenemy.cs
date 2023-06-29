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
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i));
            }
        }
    }

    private void spawn()
    {
        for(int i = 0; i < spawningPoints.Length; i += 1)
        {
            GameObject newenemy = Instantiate(enemy[Random.Range(0, enemy.Length-1)]);
            newenemy.transform.SetParent(transform);
            newenemy.transform.position = spawningPoints[i].transform.position + new Vector3(0, 0.5f,0);
        }
    }
    private Vector3 giveInfoposition(Collider col)
    {
        return col.transform.position;
    }
}
