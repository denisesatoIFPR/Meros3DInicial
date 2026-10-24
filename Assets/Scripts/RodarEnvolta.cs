using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RodarEnvolta : MonoBehaviour
{
    [SerializeField]
    Transform Player;
    [SerializeField]
    Vector3 Velo, NovaPosi;

    [SerializeField]
    float Raio;
    [SerializeField]
    float Distancia;

    public bool Parar, foi, Rodou;

    void Start()
    {
        NovaPosi = transform.position;
    }

    void Update()
    {
        Distancia = Vector3.Distance(transform.position, Player.transform.position);
        if (!Parar)
        {
            if (!foi)
            {
                NovaPosi = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-0.2f, 0.2f), transform.position.z + Random.Range(-1f, 1f));
                foi = true;
            }
            AndarPorAi();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Velo), 0.2f);
        }
        PlayerPerto();
    }

    void AndarPorAi()
    {
        if(NovaPosi != Vector3.zero){
        transform.position = Vector3.SmoothDamp(transform.position, NovaPosi, ref Velo, 6f);
        if (Vector3.Distance(transform.position, NovaPosi) < 0.2f)
        {
            NovaPosi = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-0.2f, 0.2f), transform.position.z + Random.Range(-1f, 1f));
        }
        }
    }
    void Texte()
    {
        transform.RotateAround(Player.transform.position, Vector3.up, 20 * Time.deltaTime);
        Parar = false;
        foi = false;
    }
    void PlayerPerto()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) > 2.5f && !Rodou &&  Vector3.Distance(transform.position, Player.transform.position) < 5f)
        {
            NovaPosi = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position, ref Velo, 5f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Velo), 0.2f);
        }
        if (Distancia > 1.2f && Distancia < 2.499f){
            Texte();
        }
        if (Distancia < 1.2f){
            transform.position = Vector3.SmoothDamp(transform.position, -Player.transform.position, ref Velo, 5f);
        }

    }
}