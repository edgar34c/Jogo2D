using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMascF1 : MonoBehaviour {

    private bool dir, dead;
    public float velo = 4;
    private float yZ2;
    public Animator ani;
    private float tempo = 1;

    // Use this for initialization
    void Start()
    {

    }

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
        if (yZ2 >= 23.6)
        {
            dir = false;

        }
        else if (yZ2 <= 14.8)
        {
            dir = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ataque"))
        {
            dead = true;
        }
    }
}
