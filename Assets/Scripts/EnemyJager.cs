using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJager : Enemy
{
    public Material material;
    protected override void Start()
    {
        speed = 0.05f;
        damage = 10.0f;
        target = GetComponent<Target>();
        hp = target.health;
    }

    protected override void Update()
    {
        //ударить, если можно
    }
    private void OnTriggerStay(Collider other) // поворот на игрока и ходьба
    {
        if(other.tag == "Player")
        {
            Vector3 colliderObjectPosition = new Vector3(other.transform.position.x,0.0f,other.transform.position.z);
            Vector3 newObjTransform = new Vector3(transform.position.x,0.0f, transform.position.z);
            Quaternion rotation = CalculateRotationAngle(newObjTransform, colliderObjectPosition);
            transform.rotation = rotation;
            transform.localPosition += transform.forward * speed * Time.deltaTime;
            if((colliderObjectPosition - newObjTransform).magnitude <= 2)
            {
                IGiveDamage giveDamage = other.GetComponent<IGiveDamage>();
                giveDamage.giveDamage(0.01f);
                material.color = Color.red;
            }
            else
            {
                material.color = Color.blue;
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
