using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexerCamera : MonoBehaviour
{
    public float Sensibilidade;

    public Transform Player;

    private float RotaX = 0f;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Sensibilidade *Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensibilidade *Time.deltaTime;

        RotaX -= MouseY;
        RotaX = Mathf.Clamp(RotaX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotaX,0f,0f);

        Player.Rotate(Vector3.up * MouseX);

    }
}

