using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoTartaruga : MonoBehaviour
{
    public float posX=12f, posY=27f,posZ=32f;
   public float PosTurtle=0f;
   public float Condicao=0f;
    public Transform tartaruga;
    public Vector3 velocidade;
    public bool irparaZ=true, irparaX=false,primeiravez=false,segundavez=false;
    // Start is called before the first frame update
    void Start()
    {
      if(Condicao<0)
        PosTurtle=Random.Range(-2f, -1f);
       else if(Condicao>0) PosTurtle=Random.Range(1f, 2f);
        tartaruga.transform.position=new Vector3(posX+PosTurtle,posY,posZ-PosTurtle);
    }

    // Update is called once per frame
    void Update()
    {  
        if(irparaZ){
      transform.position=Vector3.SmoothDamp(transform.position,new Vector3(posX+PosTurtle,posY,-30f), ref velocidade,9f);
         transform.rotation= Quaternion.Euler(0,0,0);
       }
      if(transform.position.z<=-29.9f){
        irparaZ=false;
        irparaX=true;
        primeiravez=true;
      }
      if(primeiravez){
         PosTurtle=Random.Range(-2f, 2f);
         transform.position=new Vector3(50f,posY,7+PosTurtle);
         primeiravez=false;
         }
         if(segundavez){
            while(PosTurtle==posX||PosTurtle==posY||PosTurtle==posZ)
             PosTurtle=Random.Range(-3f, 3f);
             
         transform.position=new Vector3(posX+PosTurtle,posY,posZ);
            segundavez=false;
         }
      if(irparaX){
        transform.rotation= Quaternion.Euler(0,95,0);
      
       
       transform.position=Vector3.SmoothDamp(transform.position,new Vector3(-30f,posY,7+PosTurtle), ref velocidade,9f);
      }
      if(transform.position.x<=-29.05f){
        transform.rotation= Quaternion.Euler(0,0,0);
       irparaZ=true;
       irparaX=false;
      primeiravez=true;
        segundavez=true;
      }
    }
}