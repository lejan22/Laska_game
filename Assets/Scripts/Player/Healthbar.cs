using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    private Animator _animator;

    public Slider slider;

    public GameObject icon;

    private void Start()
    {
        _animator = icon.GetComponent<Animator>();
    }

    //Starts with the same value as the player's life
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Making the life be the same as the player's health
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Animate()
    {
        _animator.Play("transition");
    }

}
