using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject player;
    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follows Player
        gameObject.transform.position = player.transform.position;

        // Looks at the camera
        transform.LookAt(focalPoint.transform.position);
    }
}
