using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.A))
        {
 
            transform.Translate(Vector2.left * Time.deltaTime * 10f);
        }


        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector2.down * Time.deltaTime * 10f);
        }
    }
}
