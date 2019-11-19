using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sooting : MonoBehaviour
{
    GameObject[] bulletArray = new GameObject[10];
    public Camera cm;
    public int laserSpeed;
    private IEnumerator coroutine;
    public float fireRate;
    public float reloadTime;
    public float timeToBulletDestroy;
    public Text ammoText;
    bool canShoot = true;
    bool reloading = false;
    int currentClip = 10;
    int count;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(canShoot && currentClip > 0 && !reloading)
            {
                Transform player = GetComponent<Transform>();
                GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bullet.transform.position = player.transform.position + (player.transform.forward * 1);

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
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

                coroutine = KillBullet(timeToBulletDestroy, bullet);
                StartCoroutine(coroutine);
                
                currentClip -= 1;
                ammoText.text = "Ammo: " + currentClip;

                canShoot = false;
                coroutine = WaitToBeAbleToShoot(fireRate);
                StartCoroutine(coroutine);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            coroutine = Reload(reloadTime);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator KillBullet(float waitTime, GameObject bulletToKill)
    {
        yield return new WaitForSeconds(waitTime);
        if (bulletToKill != null)
        {
            Destroy(bulletToKill);
        }
    }

    private IEnumerator WaitToBeAbleToShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    private IEnumerator Reload(float waitTime)
    {
        reloading = true;
        yield return new WaitForSeconds(waitTime);
        currentClip = 10;
        ammoText.text = "Ammo: " + currentClip;
        reloading = false;
    }
}
