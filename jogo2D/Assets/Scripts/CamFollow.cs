using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public float velo;
    public Transform alvo;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (alvo)
        {
            transform.position = Vector3.Lerp(transform.position, alvo.position, velo) + new Vector3(0, 0, -10);
        }
	}
}
