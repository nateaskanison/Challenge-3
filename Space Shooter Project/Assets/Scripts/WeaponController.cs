using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    public AudioClip shootSound;
    public AudioSource musicSource;

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    // Update is called once per frame
    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        musicSource.clip = shootSound;
        musicSource.Play();
    }
}
