using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float shotTimer = 0f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1.0f;

    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] float bulletSpeed = 12f;
    [SerializeField] float bulletOffset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CheckToShoot();        
    }

    private void CheckToShoot()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            Fire();
            shotTimer = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            new Vector2(transform.position.x, transform.position.y - bulletOffset),
            bulletPrefab.transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
