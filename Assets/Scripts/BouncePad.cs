using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    private Player_controller playercontroller;

    public float power = 20f;

    public bool shootleft;
    public bool shootup;
    public bool shootright;
    public bool shootdown;

    private Animator _animator;

    private void OnTriggerStay(Collider other)
    {


        // Obtiene el rigidbody del GameObject
        Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
       /* if (shootup == true)
        {
            playerRigidbody.AddRelativeForce(Vector3.up * power, ForceMode.Impulse);
            _animator.Play("Bounce_action");
        }
        if (shootdown == true)
        {
            playerRigidbody.AddRelativeForce(Vector3.down * power, ForceMode.Impulse);
            _animator.Play("Bounce_action");
        }
        if (shootright == true)
        {
            playerRigidbody.AddRelativeForce(Vector3.right * power, ForceMode.Impulse);
            _animator.Play("Bounce_action");
        }
        if (shootleft == true)
        {
            playerRigidbody.AddRelativeForce(Vector3.left * power, ForceMode.Impulse);
            _animator.Play("Bounce_action");
        }
       */

        playerRigidbody.AddForce(transform.up * power, ForceMode.Impulse);
    }
   
}
