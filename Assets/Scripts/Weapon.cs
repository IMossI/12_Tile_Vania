using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    // Use this for initialization

    public Transform firePoint;
    public GameObject bulletPreFab;

	// Update is called once per frame
	void Update () {

      //  Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);

        if (Input.GetButtonDown("Fire1"))

            {
                Shoot();
        }

	}
    
    void Shoot ()
    {
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
    }
}
