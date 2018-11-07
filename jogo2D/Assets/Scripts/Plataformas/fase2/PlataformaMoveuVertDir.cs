﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMoveuVertDir : MonoBehaviour {
    private bool baixo = true;
    private float vel = 2;
    private float yP;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yP = transform.position.y;
        Pos();
        if (baixo)
        {
            yP = transform.position.y;
            yP += vel * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yP);
        }
        else
        {
            yP = transform.position.y;
            yP -= vel * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yP);
        }
    }

    void Pos()
    {
        if (yP >= 2)
        {
            baixo = false;
        }
        else if (yP <= -9)
        {
            baixo = true;
        }
    }
}