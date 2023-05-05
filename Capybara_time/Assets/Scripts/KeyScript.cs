using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by Tyler Costa 19075541
 */
public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);

        }

    }
}
