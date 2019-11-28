using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sooting : MonoBehaviour
{
    private IEnumerator coroutine;
    public ParticleSystem flames;
    public GameObject flameHurtBox;
    public Camera cm;
    public Text ammoText;
    public int laserSpeed;

    public float gunSwitchDelay;
    public float fireRate;
    public float reloadTime;
    public float timeToBulletDestroy;
    public float flamerTickInterval;

    private bool canShoot = true;
    private bool reloading = false;
    private bool firing = false;

    private int currentClip = 10;
    private int gunSelection = 2;

    public static float damage;
    public float missileDamage;
    public float revolverDamage;
    public float flamerDamage;

    private int clipCap;
    public int missileClipCap;
    public int revolverClipCap;
    public int flamerClipCap;

    private int savedRevolverClip = 6;
    private int savedMissileClip = 10;
    private int savedFlamerClip = 50;

    public float GetDamage() { return damage; }
    public void SetDamage(float newDamage) { damage = newDamage; }
    public void SetClipCap(int newClipCap) { clipCap = newClipCap; }

    private void Start()
    {
        SetDamage(missileDamage);
        SetClipCap(missileClipCap);
        flames.Stop();
        flameHurtBox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gunSelection != 1)
        {
            SetDamage(revolverDamage);
            SetClipCap(revolverClipCap);
            GunSwitch(gunSelection, 1);
            gunSelection = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gunSelection != 2)
        {
            SetDamage(missileDamage);
            SetClipCap(missileClipCap);
            GunSwitch(gunSelection, 2);
            gunSelection = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && gunSelection != 3)
        {
            SetDamage(flamerDamage);
            SetClipCap(flamerClipCap);
            GunSwitch(gunSelection, 3);
            gunSelection = 3;
        }

        if (gunSelection == 2 && Input.GetButtonDown("Fire1"))
        {
            if (canShoot && currentClip > 0 && !reloading)
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

        if (gunSelection == 3 && Input.GetButton("Fire1"))
        {
            if (canShoot && currentClip > 0 && !reloading && !firing)
            {
                firing = true;
                flames.Play();
            }
            else if(canShoot && currentClip > 0 && !reloading)
            {
                flameHurtBox.SetActive(true);

                canShoot = false;
                coroutine = FlamerDamageTickInterval(flamerTickInterval);
                StartCoroutine(coroutine);

                currentClip -= 1;
                ammoText.text = "Ammo: " + currentClip;
            }
            else if (currentClip <= 0)
            {
                firing = false;
                flames.Stop();
            }
        }
        if (gunSelection == 3 && Input.GetButtonUp("Fire1"))
        {
            firing = false;
            flames.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            coroutine = Reload(reloadTime);
            StartCoroutine(coroutine);
        }
    }

    private void GunSwitch(int oldGun, int newGun)
    {
        if (oldGun == 1) { savedRevolverClip = currentClip; }
        else if (oldGun == 2) { savedMissileClip = currentClip; }
        else if (oldGun == 3) { savedFlamerClip = currentClip; }

        if (newGun == 1) { currentClip = savedRevolverClip; }
        else if (newGun == 2) { currentClip = savedMissileClip; }
        else if (newGun == 3) { currentClip = savedFlamerClip; }

        canShoot = false;
        ammoText.text = "Ammo: " + currentClip;
        coroutine = SwitchingGun(gunSwitchDelay);
        StartCoroutine(coroutine);
    }

    private IEnumerator FlamerDamageTickInterval(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        flameHurtBox.SetActive(false);
        canShoot = true;
    }

    private IEnumerator SwitchingGun(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("jou");
        canShoot = true;
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
        currentClip = clipCap;
        ammoText.text = "Ammo: " + currentClip;
        reloading = false;
    }
}
