using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	public void ChangeScene(string scene)
    {
        AtualizaHUD.coins = 0;
        AtualizaHUD.vidas = 3;
        Application.LoadLevel(scene);
    }
}
