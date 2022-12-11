using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MP5Shooting : MonoBehaviour
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

    bool FullAuto, SemiAuto;
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
    public MP5animate MP5animate; 
    private void Awake()
    {
        bulletsLeft = magazineSize;

        readyToShoot = true;
        FullAuto = false;
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MP5animate.animator.SetTrigger("Run");
        }
    }
    private void MyInput()
    {
        ////Check if allowed to hold down button and take corresponding input
        //if (allowButtonHold) shooting = Input.GetKeyDown(KeyCode.Mouse0) && FullAuto == true;

        ////shooting = Input.GetKey(KeyCode.Mouse0)

        //else
        //{
        //    shooting = Input.GetKeyDown(KeyCode.Mouse0);
        //}


        //Switch mode
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (FullAuto == true)
            {
                FullAuto = false;
                Debug.Log("Switch to SemiAuto");

            }
            else
            {
                FullAuto = true;
                Debug.Log("Switch to fullauto");
            }


        }

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
        //FullAutoShooting
        if (reloadAnimationIsPlaying == false && shooting == true && FullAuto == true && bulletsLeft > 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                timeBetweenShooting -= Time.deltaTime;

                if (timeBetweenShooting <= 0.0f)
                {
                    //Set bullets shot to 0
                    bulletsShot = 0;
                    Shoot();

                    // reset the timer
                    timeBetweenShooting = timeBetweenShots;
                }
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
        MP5animate.animator.SetTrigger("Shot");
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

        MP5animate.animator.SetTrigger("Rechange");
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


    //private void ReloadFinished() //只记录弹夹
    //{

    //    if (bulletsLeft == 0)
    //    {
    //        magazineTotal -= magazineSize;
    //    }
    //    if(bulletsLeft >= 0)
    //    {
    //        magazineTotal -= PMAG -= bulletsLeft;
    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AmmoBox")
        {
            magazineTotal = 270;
        }
    }
}
