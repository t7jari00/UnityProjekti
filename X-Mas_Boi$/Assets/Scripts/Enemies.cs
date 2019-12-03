using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float health;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 9)
        {
            TakeDamage(Sooting.damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            TakeDamage(Sooting.damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(Sooting.damage);
    }
}
