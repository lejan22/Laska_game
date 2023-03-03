using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public Animator animated;

    private bool collected;

    

    GameObject player;

    private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameManager = FindObjectOfType<GameManager>();

    }

    

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            animated.SetBool("collected", true);
            Destroy(gameObject,0.6f);
            
            

            gameManager.UpdateScore();
        }
    }
}
