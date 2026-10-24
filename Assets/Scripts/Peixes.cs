using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixes : MonoBehaviour
{
    [Header("Quão longe ele vai nesta variavel")]
    public float[] RangeX = new float[] {-1f,1f};
    public float[] RangeZ = new float[] {-1f,1f};
    
     
    [Header("Velocidades")]
    [Range(0f,5f)]
    [SerializeField] private float Velocidade;
    [Range(0f, 5f)]
    [SerializeField] private float VelocidadeOlhar;

    [Header("Outros Status")]
    [SerializeField] private float Raio;
    [SerializeField] private float Distancia;

    private float TempoEspera = 3f;

    [Header("Posição que o peixe esta indo")]
    [SerializeField] Vector3 NovaPosi;
    private bool Chamou = false;
    private bool Fugindo = false;
    
    [Header("Player")]
    [SerializeField] Transform Player;
    Quaternion OndeOlhar;
    void Start()
    {
        //Aleatoriza as posições no inicio.
        Aleatorizar();
    }
    void Update()
    {
        //tentando implementar a funcao de o player chegar perto dos peixes e eles irem para longe por isso a bool "fugindo"
        if (!Fugindo) MudarPosi();
        //declara para onde o peixe deve olhar se o OndeOlhar nao for ser nulo
        if (NovaPosi.x - transform.position.x != 0)OndeOlhar = Quaternion.LookRotation(NovaPosi - transform.position);
        Fugir();   
    }
    void MudarPosi()
    {   
        //Se a posição for diferente da que queremos que o peixe esteja ele vai se mover a tal posição, se nao isso significa que ele esta na posição desejada e aleatoriza uma nova.
        if (transform.position != NovaPosi)
        {
            transform.position = Vector3.MoveTowards(transform.position, NovaPosi, Velocidade * Time.deltaTime);
            //rotaciona o a frente do peixe para onde ele esta indo 
            transform.rotation = Quaternion.Slerp(transform.rotation, OndeOlhar, VelocidadeOlhar * Time.deltaTime);
        }
        if (transform.position == NovaPosi && !Chamou)
        {
            Chamou = true;
            StartCoroutine(Aleaposi());
        }
    }
    IEnumerator Aleaposi()
    {
        //A cada tanto segundos ele aleatoriza, fiz isso para ele ficar um tempo parado antes de ir para proxima posição
        yield return new WaitForSeconds(TempoEspera);
        if (transform.position == NovaPosi)
        {
            Aleatorizar();        
        }
        StartCoroutine(Aleaposi());
    }
    void Fugir()
    {
        // ainda nao esta funcionando muito bem.
        // calcula distancia e se for menor que o raio entao o peixe foge do player indo na posição contraria.
        Distancia = Vector3.Distance(transform.position, Player.position);
        if (Distancia < Raio)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -4 * Time.deltaTime);
            Fugindo = true;
        }
        else Fugindo = false;      
    }
   
    void Aleatorizar()
    {
        //aleatoriza a nova posição, no x e de quanto esta no rangex, no y e de -0.3 a 0.3 e finalmente no z e de quanto esta no rangez.
        NovaPosi = new Vector3(transform.position.x + Random.Range(RangeX[0],RangeX[1]), transform.position.y + Random.Range(-0.3f, 0.3f), transform.position.z + Random.Range(RangeZ[0],RangeZ[1]));      
    }
}
