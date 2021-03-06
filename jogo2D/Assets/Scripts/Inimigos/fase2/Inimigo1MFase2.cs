﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1MFase2 : MonoBehaviour {

    private bool dir, dead;
    public float velo = 3.5f;
    private float yZ2;
    public Animator ani;
    private float tempo = 1;

    // Update is called once per frame
    void Update()
    {
        yZ2 = transform.position.x;
        posi();
        if (dir)
        {
            yZ2 = transform.position.x;
            yZ2 += velo * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 0);
            transform.position = new Vector2(yZ2, transform.position.y);

        }
        else
        {
            yZ2 = transform.position.x;
            yZ2 -= velo * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 180);
            transform.position = new Vector2(yZ2, transform.position.y);
        }

        if (dead)
        {
            ani.SetBool("morrer", true);
            velo = 0;
            if (tempo > 0)
            {
                tempo -= Time.deltaTime;
            }

            if (tempo <= 0)
            {
                ani.SetBool("morrer", false);
                Destroy(gameObject);
            }
            
        }
    }

    void posi()
    {
        if (yZ2 >= 36)
        {
            dir = false;

        }
        else if (yZ2 <= 27.3)
        {
            dir = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ataque"))
        {
            dead = true;
        }
    }
}
