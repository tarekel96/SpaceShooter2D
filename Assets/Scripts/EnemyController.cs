﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float timerBullet;
    private float maxTimerBullet;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        timerBullet = 0;
        maxTimerBullet = Random.Range(5f, 25f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FireBullet");
        // destroys enemy once it gets out of camera viewport
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.y -= (bullet.GetComponent<Renderer>().bounds.size.y /2) + (GetComponent<Renderer>().bounds.size.y / 2);
        GameObject.Instantiate(bullet, spawnPoint, transform.rotation);
    }

    IEnumerator FireBullet()
    {
        if (timerBullet >= maxTimerBullet)
        {
            // spawn an enemy
            SpawnBullet();
            timerBullet = 0;
            maxTimerBullet = Random.Range(5f, 12f);
        }

        timerBullet += 0.1f;
        // yield for CoRoutine
        yield return new WaitForSeconds(0.1f);
    }
}
