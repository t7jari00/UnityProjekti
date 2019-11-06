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
            bulletRb.transform.position = player.position;

            float x = Screen.width / 2f;
            float y = Screen.height / 2f;

            var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
            bulletRb.velocity = ray.direction * laserSpeed;
        }
    }
}
