using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinho : MonoBehaviour {

    public float yE, vel=1;
    private bool baixo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        yE = transform.position.y;
        Pos();
        if (baixo)
        {
            yE = transform.position.y;
            yE += vel * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yE,transform.position.z);
        }
        else
        {
            yE = transform.position.y;
            yE -= vel * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yE, transform.position.z);
        }
    }

    void Pos()
    {
        if (yE >= -5.67)
        {
            baixo = false;
        }
        else if (yE <= -7.7)
        {
            baixo = true;
        }
    }
}
