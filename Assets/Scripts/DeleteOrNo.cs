using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOrNo : MonoBehaviour
{
    public float percentForDelete = 0.5f;
    void Start()
    {
        if(Random.value > percentForDelete) Destroy(gameObject);
    }
}
