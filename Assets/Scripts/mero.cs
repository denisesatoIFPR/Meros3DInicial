using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mero : MonoBehaviour
{
    [SerializeField] private GameObject Cabeca;  
   [SerializeField] private Transform Player; 
   [SerializeField] private Vector3 Velo, NovaPosi; 
   [SerializeField] private Animator Animim;
   
    private bool Parar, foi, Rodou, Embora;
    void Start() {NovaPosi = transform.position;}
    void Update()
    {
        Cabeca.transform.forward = -transform.right;
      
        Animim.SetFloat("Velo", Mathf.Clamp((Mathf.Abs(Velo.x) + Mathf.Abs(Velo.y) + Mathf.Abs(Velo.z)) * 2f, 0.1f, 1.5f));

        if (!Parar)
        {
            if (!foi)
            {
                Aleatorizar();
                foi = true;
            }
            if (NovaPosi != Vector3.zero)AndarPorAi();
        }
    }
    void Rotacionar()
    {
        if (Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Velo), 0.3f * Time.deltaTime) != new Quaternion(0, 0, 0, 0))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Velo), 0.8f * Time.deltaTime);
    }
    void Aleatorizar() { NovaPosi = new Vector3(transform.position.x + Random.Range(-3f, 3f), transform.position.y , transform.position.z + Random.Range(-3f, 3f));}
    void AndarPorAi()
    {
        Rotacionar();
        transform.position = Vector3.SmoothDamp(transform.position, NovaPosi, ref Velo, 3f);
        if (Vector3.Distance(transform.position, NovaPosi) < 0.2f) Aleatorizar();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("parede"))
        {
            NovaPosi = new Vector3(8.51f, 7.779f, 8.1f) - transform.position / (new Vector3(8.51f, 7.779f, 8.1f) - transform.position).magnitude;
            NovaPosi.y = transform.position.y;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            NovaPosi = ((Player.position - transform.position) / (Player.position - transform.position).magnitude) + transform.position;
            NovaPosi.y = transform.position.y;
        }
    }
}


