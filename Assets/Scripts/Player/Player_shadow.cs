using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shadow : MonoBehaviour
{

    public GameObject player;

    private Vector3 hitDataPoint;
    private float groundDistance;

    void Update()
    {
        // Raycast looking down
        if (Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hitData, 50))
        {
            // Saves the hit from the Raycast
            hitDataPoint = hitData.point;

            // Changes the axis of this Vector3
            hitDataPoint.y += 0.1f;

            // Follows position of the hitpoint
            transform.position = hitDataPoint;

            // gets the ground distance
            groundDistance = transform.position.y - player.transform.position.y;

            //Changes scale of the shado depending on the height from the ground
            transform.localScale = Vector3.one * -groundDistance;
        }
    }
}
