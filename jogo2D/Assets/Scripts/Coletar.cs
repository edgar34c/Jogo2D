﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletar : MonoBehaviour {

    CircleCollider2D col;
    private int coin;
    public AudioSource a;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            a.Play();
            AtualizaHUD.coins++;
            Destroy(gameObject);

        }
    }
}
