using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimenta : MonoBehaviour
{
    void Update(){
        transform.position += (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * Time.deltaTime;
    }
}