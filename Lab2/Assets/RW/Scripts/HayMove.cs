using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class HayMove : MonoBehaviour
{
    public Vector3 movementSpeed;
    public Space space;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }

   
}
