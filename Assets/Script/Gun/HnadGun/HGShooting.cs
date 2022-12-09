using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HGShooting : MonoBehaviour
{
    public GameObject bullet;
    //bullet force
    public float shootForce, upwardForce;
    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots, reloadDuration;

    public int magazineSize, bulletsPreTap, magazineTotal, PMAG;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;
    //bool
    bool shooting, readyToShoot, reloading, reloadAnimationIsPlaying;

    
    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public Transform muzzlePoint;


    //bug fixing
    public bool allowInvoke = true;

    //Graphic
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //ShootSound
    public AudioSource Shot;
    public AudioClip Bullet;

    public float fireRate, nextFire;

    //Gun animate
    public HandGUNanim HandGun;
    private void Awake()
    {
        bulletsLeft = magazineSize;

        readyToShoot = true;
       
        shooting = true;

    }
    private void Start()
    {
        PMAG = 0;
    }
    private void Update()
    {

        if (Time.timeScale >= 1f) // Time.deltaTime <= 0.0f
        {
            MyInput();
        }


        //Set ammo display
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPreTap + "/" + magazineTotal / bulletsPreTap);
        }

        if (magazineTotal <= 0)
        {
            reloading = false;
        }
        else
        {
            reloading = true;
        }
    }
    private void MyInput()
    {
        


      

        //Shooting
        if (reloadAnimationIsPlaying == false && shooting == true && bulletsLeft > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Set bullets shot to 0
                bulletsShot = 0;
                Shoot();
            }

        }
        

        //Reload
        //按弹夹换弹
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && reloading == true)
        {
            //SCAR.animator.SetTrigger("Rechange");
            PMAG = magazineSize - bulletsLeft;
            Reload();

        }
        //automatic reload when no ammo， 自动没子弹换弹
        if (bulletsLeft <= 0 && reloading == true)
        {
            //SCAR.animator.SetTrigger("Rechange");
            PMAG = magazineSize - bulletsLeft;
            Reload();

        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        //animation
        HandGun.animator.SetTrigger("Shot");
        //RAYCAST finding hit position
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        //Check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
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
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet

        Shot.PlayOneShot(Bullet);
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);


        //GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);



        //Instantiate muzzle flash
        if (muzzleFlash != null)
        {
            Instantiate(muzzleFlash, muzzlePoint.position, Quaternion.identity);
        }
        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
        if (bulletsShot < bulletsPreTap && bulletsLeft > 0)
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

        HandGun.animator.SetTrigger("Rechange");
        //Invoke("ReloadFinished", reloadTime);

        reloadAnimationIsPlaying = true;

        bulletsLeft = magazineSize;



        if (bulletsLeft == 0)
        {
            magazineTotal -= magazineSize;
        }
        if (bulletsLeft > 0)
        {


            magazineTotal -= PMAG;
        }

        StartCoroutine(reloadSequence());

    }

    private IEnumerator reloadSequence()
    {
        yield return new WaitForSeconds(reloadDuration);

        // set boolean to false
        reloadAnimationIsPlaying = false;
    }


   
}
