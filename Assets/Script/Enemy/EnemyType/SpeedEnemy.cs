using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[Serializable]

public class SpeedZombie : MonoBehaviour
{
    public Transform body;
     public Transform[] leg;
    public float[] maxDis ;
    [SerializeField] float[] dis ;

    void Start(){
        dis = new float[leg.Length];
        maxDis = new float[leg.Length];
    for(int i = 0; i<leg.Length;i++)
        maxDis[i] =  Vector3.Distance(transform.position,leg[i].position);
    }


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < leg.Length ;i++)
        {
            dis[i] = Vector3.Distance(transform.position,leg[i].position);

            if(dis[i] > maxDis[i])
            {
                Debug.Log(1);
                var targetPos = (transform.position - leg[i].position) *0.5f;
                leg[i].position = Vector3.Slerp(leg[i].position, targetPos,0.01f);
            }
            }
       
       if ( Vector3.Distance(body.position,transform.position)<2){
         body.position = Vector3.Slerp(body.position, transform.position,0.5f);
       }
    }

   void OnDrawGizmos(){
       for(int i = 0; i<leg.Length;i++)
         Gizmos.DrawSphere(leg[i].position, 0.1f);
    }
      
   
}
