using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJager : Enemy
{
    private bool cangiveDamage = true;
    private float deley = 10;
    protected override void Start()
    {
        speed = 0.05f;
        damage = 10.0f;
    }
    private void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other) // поворот на игрока и ходьба
    {
        if(other.tag == "Player")
        {
            Vector3 colliderObjectPosition = new Vector3(other.transform.position.x,0.0f,other.transform.position.z);
            Vector3 newObjTransform = new Vector3(transform.position.x,0.0f, transform.position.z);
            Quaternion rotation = CalculateRotationAngle(newObjTransform, colliderObjectPosition);
            transform.rotation = rotation;
            
            if((colliderObjectPosition - newObjTransform).magnitude <= 2)
            {
                if (cangiveDamage)
                {
                    cangiveDamage = false;
                    IGiveDamage giveDamage = other.GetComponent<IGiveDamage>();
                    giveDamage.giveDamage(0.01f);

                }
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
    }

    private Quaternion CalculateRotationAngle(Vector3 fromPosition, Vector3 toPosition)
    {
        Vector3 direction = toPosition - fromPosition;
        Quaternion rotation = Quaternion.LookRotation(direction);
        return rotation;
    }

    IEnumerator Hit(Collider other)
    {
        IGiveDamage giveDamage = other.GetComponent<IGiveDamage>();
        giveDamage.giveDamage(5);
        yield return new WaitForSeconds(2.0f);
    }
}
