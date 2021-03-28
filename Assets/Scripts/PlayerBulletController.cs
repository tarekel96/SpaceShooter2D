﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        // destroys rocket once it gets out of camera viewport
        if(Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
