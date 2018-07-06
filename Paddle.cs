using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // Use this for initialization
    public bool autoPlay = false;
    private Ball ball;
	
    private void Start()
	{
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball);
	}

	// Update is called once per frame
	void Update () {
        if (autoPlay == false)
        {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void AutoPlay(){
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3  ballPos = ball.transform.position;
        //print(mousePosInBlocks);
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;

    }
    void MoveWithMouse (){
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        //print(mousePosInBlocks);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;

    }
}
