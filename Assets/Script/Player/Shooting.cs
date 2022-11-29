using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    //bullet force
    public float shootForce,upwardForce;
    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;

    public int magazineSize, bulletsPreTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;
    //bool
    bool shooting, readyToShoot, reloading;
    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //bug fixing
    public bool allowInvoke = true;

    //Graphic
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    private void Awake()
    {
        bulletsLeft = magazineSize;

        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Set ammo display
        if(ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPreTap + "/" + magazineSize / bulletsPreTap);
        }
    }
    private void MyInput()
    {   
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKeyDown(KeyCode.Mouse0);
        else shooting = Input.GetKey(KeyCode.Mouse0);

        //Shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;
            Shoot();
        }
        //Reload
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading )
        {
            Reload();
        }
        //automatic reload when no ammo
        if(readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //RAYCAST finding hit position
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;
        //Check if ray hits something
        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); // Just a point far away from player
        }

        //Calculate direction from a attackPoint TO TARGETpOINT
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new directoin with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        //Instantiate muzzle flash
        if(muzzleFlash != null)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }
        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function
        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
        if(bulletsShot < bulletsPreTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
