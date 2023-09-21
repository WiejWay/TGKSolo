using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // This method is called once when the script/component is first enabled.
        // You can initialize variables or perform setup here.
    }

    // Update is called once per frame
    void Update()
    {
        // This method is called once per frame. 
        // It's where you put code that should run every frame.

        // Check if the D key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            // Move the UFO to the right
            transform.Translate(Vector2.right * Time.deltaTime * 5f);
        }

        // Check if the W key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Move the UFO up
            transform.Translate(Vector2.up * Time.deltaTime * 5f);
        }

        // Check if the A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Move the UFO to the left
            transform.Translate(Vector2.left * Time.deltaTime * 5f);
        }

        // Check if the S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            // Move the UFO down
            transform.Translate(Vector2.down * Time.deltaTime * 5f);
        }
    }
}
