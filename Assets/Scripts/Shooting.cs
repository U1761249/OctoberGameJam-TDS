using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject shot;
    public Transform bulletSpawn;
    private float fireRate = 0.3f;
    private float lastFire = 0;

    void Start()
    {
        bulletSpawn = GetComponent<Transform>();
    
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > lastFire)
        {
            lastFire = Time.time + fireRate;

            Instantiate(shot, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    
}
