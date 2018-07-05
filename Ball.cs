using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;

    private Vector3 paddletoBallVector;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddletoBallVector = this.transform.position - paddle.transform.position;
        //print(paddletoBallVector.y);

	}
	// wasuup buddy how are you 22
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddletoBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

            }
        }
	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
        Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        //print(tweak);
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            //rigidbody2D.velocity += tweak;
        }
	}
}
