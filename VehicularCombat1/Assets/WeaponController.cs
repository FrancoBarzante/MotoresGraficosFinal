using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    public GameObject particlesPrefab;
    private float nextFireTime;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject nuevasParticulas = Instantiate(particlesPrefab, firePoint.position, firePoint.rotation);

        ParticleSystem particulas = nuevasParticulas.GetComponent<ParticleSystem>();
        particulas.Play();
    }
}

