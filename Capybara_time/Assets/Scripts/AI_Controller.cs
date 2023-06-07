using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{

    public Transform target;
    public Transform myTransform;

    void Update(){
        myTransform.LookAt(target);
        myTransform.Translate(Vector3.forward*5*Time.deltaTime);
    }
   
}
