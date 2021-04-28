using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    AudioSource goal;

    //public int count;

   
    //Codigo cuando choca contra otro objeto
    private void OnCollisionEnter(Collision collision)
    {
    //count++;
    //print(" IT'S A GOAAL " + "team "+ collision.gameObject.name + count + " goals!");
    goal.Play();
    }
    private void OnCollisionExit(Collision collision)
    {
    }

    void Start()
    {
    goal = GetComponent<AudioSource>();
    //count = 0;
    }

}
