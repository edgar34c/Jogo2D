using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMoveu : MonoBehaviour {

    private bool direita = true;
    private float vel = 2;
    private float xp;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xp = transform.position.x;
        Pos();
        if (direita)
        {
            xp = transform.position.x;
            xp += vel * Time.deltaTime;
            transform.position = new Vector3(xp, transform.position.y);
        }
        else
        {
            xp = transform.position.x;
            xp -= vel * Time.deltaTime;
            transform.position = new Vector3(xp, transform.position.y);
        }
	}

    void Pos()
    {
        if(xp <= 28)
        {
            direita = true;
        }
        else if(xp >= 35)
        {
            direita = false;
        }
    }
}
