using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerObstacle : MonoBehaviour
{
    AudioSource pum;
    private float delay, timer;
    public int count;

    //Codigo si se atraviesa un objeto
    /*private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name + "enter the cube");
        pum.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name + "stay the cube");
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.gameObject.name + "exit the cube");
    }*/

    //Codigo cuando choca contra otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        count++;
        print(collision.gameObject.name + " You collided to " + this.gameObject.name + " " + count + " times and lost!");
        pum.Play();
    }
    private void OnCollisionExit(Collision collision)
    {
    }

    void Start()
    {
        pum = GetComponent<AudioSource>();
        count = 0;
        delay = 5; // cada 5 seg objetos se mueven de arriba a abajo
    }

    void Update()
    {
        timer += Time.deltaTime;
        //print(timer);
        if (timer > delay)
        {
            //If so, proceed to translate the object:
            timer = Time.deltaTime - timer;
        }
        else if (timer < 0)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime);

        }
    }
}
