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

    //Que el slider empieze concorde a la vida maxima que tiene el jefe
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Para hacer que el slider concuerde con la vida del boss
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Animate()
    {
        _animator.Play("transition");
    }

}
