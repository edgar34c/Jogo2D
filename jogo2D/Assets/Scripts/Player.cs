using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //VARIAVEIS
    //pega posição inicial do player
    private float ini_x, ini_y;

    //controle de animação
    public Animator animeP;

    //controle de física
    public Rigidbody2D PlayerRigidBody;

    //variaveis de controle de movimento
    private int velocidade = 5;
    public float forcaPulo = 441;
    private float t, time = 1.5f;
    private float j;
    private bool esquerda;

    //variavel para checar se o Player está no chão
    private bool checaChao;
    public LayerMask eChao;
    public Transform checaChaoT;

    //audio
    private AudioSource aud;

    //controle morte player
    private bool colisao;

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
        ini_x = transform.position.x;
        ini_y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        //movimentação horizontal
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            t = transform.position.x;
            t += velocidade * Time.deltaTime;
            transform.position = new Vector2(t, transform.position.y);
            transform.eulerAngles = new Vector2 (0, 0);
            animeP.SetBool("andando", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animeP.SetBool("andando", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            t = transform.position.x;
            t -= velocidade * Time.deltaTime;
            esquerda = true;
            transform.position = new Vector2(t, transform.position.y);
            transform.eulerAngles = new Vector2(0, 180);
            animeP.SetBool("andando", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            animeP.SetBool("andando", false);
            esquerda = false;
        }

        //verifica se o player está no chão
        checaChao = Physics2D.OverlapCircle(checaChaoT.position, 0.2f, eChao);

        //controles de pulo
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) && checaChao)
        {
            aud.Play();
            PlayerRigidBody.AddForce(Vector2.up * forcaPulo);
            animeP.SetBool("pulando", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            animeP.SetBool("pulando", false);
        }

        //verifica se o player colidiu com os zumbis e tira um vida
        if (colisao)
        {
            time -= Time.deltaTime;
            if (time > 0)
            {
                animeP.SetBool("morrendo", true);
                forcaPulo = 0;
                velocidade = 0;
            }
            if (time < 1)
            {
                colisao = false;
                animeP.SetBool("morrendo", false);
                transform.position = new Vector2(ini_x, ini_y);
                transform.eulerAngles = new Vector2(0, 0);
                forcaPulo = 441;
                velocidade = 5;
                AtualizaHUD.vidas -= 1;
                AtualizaHUD.coins -= 1;
                time = 1.5f;
            }

        }

        //diminui a força do pulo para 335 se estiver na fase 2
        if (Application.loadedLevelName == "fase2")
        {
            forcaPulo = 335;
        }

    }

    //verifica se o personagem colidiu com algo
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se colidir com o inimigo
        if (other.CompareTag("inimigo"))
        {
            colisao = true;
        }

        //se cair no acido e tira vida
        if (other.CompareTag("queda"))
        {
            transform.position = new Vector2(ini_x, ini_y);
            transform.eulerAngles = new Vector2(0, 0);
            AtualizaHUD.vidas -= 1;
            AtualizaHUD.coins -= 1;
        }

        //pisar na ultima plataforma da fase
        if (other.CompareTag("chao"))
        {
            if (Application.loadedLevelName == "fase2")
            {
                Application.LoadLevel("ganhou");
            }
            else
            {
                Application.LoadLevel("fase2");
            }
        }

    }
}
