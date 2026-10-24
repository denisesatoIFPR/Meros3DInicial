using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public float Velocidade;
    public float Gravidade;
    public Rigidbody rg;
    public float Nado;
    private Vector3 PlayerMove;
    public Transform Agua;
    void Update()
    {
        MoveXZ();
        MoveY();
        
    }
    void MoveXZ()
    {
        PlayerMove = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 Movi = transform.TransformDirection(PlayerMove) * Velocidade;
        rg.linearVelocity = new Vector3(Movi.x, rg.linearVelocity.y, Movi.z);
    }
    void MoveY()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Agua.position.y > transform.position.y)
        {
             rg.AddForce(Vector3.up * Nado, ForceMode.Impulse);     
        }
        if (Agua.position.y < transform.position.y)
        {
            rg.mass = 2;
            Physics.gravity = new Vector3(0, -20f, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -2f, 0);
            rg.mass = 0.1f;
        }
    }
}
