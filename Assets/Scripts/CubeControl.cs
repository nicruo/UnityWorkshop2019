using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public string name = "hello";
    public float force = 1;

    private Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            body.AddForce(new Vector3(0,1*force,0));
        }

        if(Input.GetKey(KeyCode.S))
        {
            body.AddForce(new Vector3(0,-1*force,0));
        }
    }
}
