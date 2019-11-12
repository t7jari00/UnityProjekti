using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion"));
        explosion.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
