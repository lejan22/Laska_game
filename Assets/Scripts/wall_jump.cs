using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_jump : MonoBehaviour
{
    public Player_controller player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!player.IsOnGround() && hit.normal.y <0.1f)
        {
            if ((Input.GetKeyUp(KeyCode.Space)))
            {
                player.Jumping();
                
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            }
        }
        
    }
}
