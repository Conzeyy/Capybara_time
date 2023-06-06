using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created by Tyler Costa 19075541
 */
public class KeyScript : MonoBehaviour
{
    public float translationAmount = 1f;
    public float bounceDuration = 1f;
    public float rotationDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(keyBounce());

    }

    // Update is called once per frame
    void Update()
    {



    }


    IEnumerator keyBounce()
    {
        Vector3 startPosition = transform.position;

        while (true)
        {
            // Move upwards
            float timer = 0f;
            while (timer < bounceDuration)
            {
                timer += Time.deltaTime;

                // Calculate the new position using a bouncing effect
                float newY = startPosition.y + Mathf.Sin(timer * Mathf.PI / bounceDuration) * translationAmount;
                transform.position = new Vector3(startPosition.x, newY, startPosition.z);

                yield return null;
            }

            // Move downwards
            timer = 0f;
            while (timer < bounceDuration)
            {
                timer += Time.deltaTime;

                // Calculate the new position using a bouncing effect
                float newY = startPosition.y + Mathf.Sin(timer * Mathf.PI / bounceDuration) * translationAmount;
                transform.position = new Vector3(startPosition.x, newY, startPosition.z);

                yield return null;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);

        }

    }
}
