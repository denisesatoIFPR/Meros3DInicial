using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player, Camera;
void Update(){
player.rotation=Quaternion.Euler(player.eulerAngles.x,Camera.eulerAngles.y,player.eulerAngles.z);
}
}
