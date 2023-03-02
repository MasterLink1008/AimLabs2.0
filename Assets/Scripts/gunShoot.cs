using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    #region Variables
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject hitEffect;
    public float hitForce = 30f;
    public static float Score;
    public int tTargetScore = 1;
    #endregion
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && MainMenu.Tracker == false)
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.Mouse0) && MainMenu.Tracker == true)
        {
            Shoot2();
        }
    }

    void Shoot()
    {   
            MuzzleFlash.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target =hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
                Score += 1;
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }

            
                GameObject impactGO = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            
        }
    }

    void Shoot2()
    {
        RaycastHit hit2;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range)) 
        {
            TrackerTarget tTarget = hit2.transform.GetComponent<TrackerTarget>();

            if (tTarget != null)
            {
                tTarget.SetTrackerScore(tTargetScore);
            } 
        }
    }
}
