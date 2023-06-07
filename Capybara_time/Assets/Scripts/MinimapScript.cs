using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void LateUpdate()
    {
        // Get the position of the player character
        Vector3 playerPosition = playerTransform.position;

        // Set the position of the minimap camera to the same x and z coordinates as the player character, but keep the y coordinate of the camera
        transform.position = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);

        // Reset the rotation of the minimap camera so it doesn't rotate with the player character
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}

