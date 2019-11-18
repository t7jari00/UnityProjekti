using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sooting : MonoBehaviour
{
    public Camera cm;
    public int laserSpeed;
    int count;
    GameObject[] bulletArray = new GameObject[10];
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Transform player = GetComponent<Transform>();
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bullet.transform.position = player.transform.position;

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Vector3 direction = hit.point - bullet.transform.position;
                bulletRb.velocity = direction.normalized * laserSpeed;
            }
            else
            {
                float x = Screen.width / 2f;
                float y = Screen.height / 2f;
                var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
                bulletRb.velocity = ray.direction * laserSpeed;
            }

        }
    }
}
