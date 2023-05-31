using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrayScript : MonoBehaviour
{
    public float translationAmount = 1f;
    public float bounceDuration = 1f;
    public float rotationDuration = 3f; // Duration for one complete revolution in seconds

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(foodTrayBounce());
        float rotationSpeed = 360f / rotationDuration; // Calculate rotation speed in degrees per second
        StartCoroutine(foodTrayRotate(rotationSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator foodTrayRotate(float rotationSpeed)
    {
        while (true) // Infinite loop for continuous rotation
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World); // Rotate the object on the Y-axis
            yield return null; // Wait for the next frame
        }
    }
    IEnumerator foodTrayBounce()
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
