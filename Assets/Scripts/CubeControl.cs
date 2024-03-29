﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeControl : MonoBehaviour
{
    public float magnitude;
    public float force = 1;

    private Rigidbody body;

    private float horizontal;
    private float vertical;

	public bool playable;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
		if (playable)
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");
		}
        else
		{
			horizontal = 0;
			vertical = 0;
		}
    }

    private void FixedUpdate()
    {
        magnitude = body.velocity.magnitude;
        if (body.velocity.magnitude <= 50)
        {
            body.AddForce(new Vector3(horizontal, 0, vertical) * force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
