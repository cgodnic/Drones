using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float fireRate = .5f;
    public float fireRange = 50f;
    public float hitForce = 100f;
    public int laserDamage = 100;
    public static int hitCount = 10;

    private LineRenderer laserLine; // predstavlja linijo laserja

    private bool laserLineEnabled; // ali streljamo

    private WaitForSeconds laserDuration = new WaitForSeconds(0.05f);

    // cas do naslednjega strela
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        // getting the Line Renderer
        laserLine = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && (TimerScript.time > 0))
        {
            Fire();
            SFXmanager.sfxInstance.Audio.PlayOneShot(SFXmanager.sfxInstance.Click);
        }
    }

    private void Fire()
    {
        // ARCamera Transform
        Transform cam = Camera.main.transform;

        // cas do naslednjega strela
        nextFire = Time.time + fireRate;

        // raycast
        Vector3 rayOrigin = cam.position;

        // originalna posicija laserja vedno 10 enot od AR kamere
        laserLine.SetPosition(0, transform.up * -10f);
       
        RaycastHit hit;

        // Preverimo �e smo zadeli objekt
        if (Physics.Raycast(rayOrigin, cam.forward, out hit, fireRange))
        {
            // konec laserja nastavi na zadet objekt
            laserLine.SetPosition(1, hit.point);

            CubeBehaviourScript cubeCtr = hit.collider.GetComponent<CubeBehaviourScript>();
            if ( cubeCtr != null ) {
                if ( hit.rigidbody != null ) {
                    // potrdi da si zadel
                    hit.rigidbody.AddForce(-hit.normal*hitForce);
                    // potrdi damage
                    cubeCtr.Hit( laserDamage );
                    hitCount--;
                }
            }

        }
        else
        {
           laserLine.SetPosition(1, cam.forward * fireRange);
        }

        // prikazi laser
        StartCoroutine(LaserFx());
    }

    private IEnumerator LaserFx()
    {
        laserLine.enabled = true;
        // Way for a specific time to remove the LineRenderer
        yield return laserDuration;
        laserLine.enabled = false;

    }
}
