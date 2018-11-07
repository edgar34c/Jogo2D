using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

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
        //pega localização do personagem no eixo X
        yZ2 = transform.position.x;
        //roda o metodo posi
        posi();
        
        //controla a direção que o inimigo anda
        if (dir)
        {
            //pega posição x
            yZ2 = transform.position.x;
            //adiciona a velocidade
            yZ2 += velo * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 0);
            //faz o descolamento do inimigo
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

    //metodo para mudar direção quando o inimigo chegar ao limite
    void posi()
    {
        //neste caso o limite é 3.57
        if (yZ2 >= 3.57)
        {
            dir = false;

        }
        else if (yZ2 <= -3.54)
        {
            dir = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        //se o personagem colidir com a cabeça do inimigo
        if (coli.CompareTag("ataque"))
        {
            dead = true;
        }
    }


}
