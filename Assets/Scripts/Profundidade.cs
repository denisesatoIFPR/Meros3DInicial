using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profundidade : MonoBehaviour
{
    [SerializeField]
    Transform Chao, Oceano, Player;
    [SerializeField]
    Text Texto;

    private void Update()
    {
      Texto.text = (Mathf.Round(Mathf.InverseLerp(Oceano.position.y,Chao.position.y, Player.position.y) * 100)).ToString();
    }

}
