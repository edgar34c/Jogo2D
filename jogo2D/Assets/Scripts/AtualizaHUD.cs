using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizaHUD : MonoBehaviour {
    public static int coins, vidas = 3;
    private float minutos,  temp;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "fase1" || Application.loadedLevelName == "fase2")
        {
            GameObject.Find("coinText").GetComponent<Text>().text = coins.ToString();
            GameObject.Find("vidasText").GetComponent<Text>().text = vidas.ToString();
        }
        
        if (Application.loadedLevelName == "Ganhou")
        {
            GameObject.Find("Pontos").GetComponent<Text>().text = coins.ToString();
        }

        if (coins < 0)
        {
            coins = 0;
        }

        if (vidas < 1)
        {
            Application.LoadLevel("fimDeJogo");
        }
        else if(Application.loadedLevelName == "fase1" || Application.loadedLevelName == "fase2")
        {
            temp += Time.deltaTime;
            GameObject.Find("segundos").GetComponent<Text>().text = temp.ToString("f0");
            if(temp >= 60)
            {
                minutos = temp / 60;
                temp = 0;
                GameObject.Find("minutos").GetComponent<Text>().text = minutos.ToString("f0");
            }
        }
    }

}
