﻿using UnityEngine;


namespace ProjectSpacer
{

    public class KineticWeapon : MonoBehaviour
    {

        public GameObject Bullet;
        public float fireRate = 0.1f;
        public float recoil = 0.0f;
        public float projectileSpawn = 3f;
        public bool IsFiring;
        public Rigidbody2D rb;


        private float nextFire = 0.0f;

        public void Fire()
        {

            GameObject bullet;


            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bullet = (GameObject)Instantiate(Bullet, transform.position + transform.up * projectileSpawn, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                rb.AddForce(transform.up * recoil);
                //bulletSound.Play();

            }

        }

    }
}
