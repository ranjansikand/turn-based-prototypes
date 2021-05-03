using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	GameObject gameManager;

	private bool moveMade = false;
	private float waitTime;

	private bool objDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        waitTime = Random.Range(0.2f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
    	if (gameManager.GetComponent<GameManager>().PlayerTurn()) {
    		moveMade = false;
    		objDetected = false;
    	}
        if (!(gameManager.GetComponent<GameManager>().PlayerTurn()) && !(moveMade)) {
        	PrepMove();
        	moveMade = true;
        }
    }

    void FixedUpdate()
    {
        // Vector3 fwd = transform.TransformDirection(new Vector3(-1, 0, 0));

        // if (Physics.Raycast(transform.position, fwd, 20)) {
        // 	objDetected = true;
        // }
    }

    void PrepMove() {
    	Vector3 fwd = transform.TransformDirection(new Vector3(-1, 0, 0));
    	if (Physics.Raycast(transform.position, fwd, 20)) {
    		Debug.Log(objDetected);
    	    Invoke("Move", waitTime);
    	} else {
    		Invoke("MoveSideways", waitTime);
    	}
    }

    void Move() {
    	transform.position = transform.position + new Vector3(-2,0,0);
    	gameManager.GetComponent<GameManager>().EnemyPieceMoved();
    }

    void MoveSideways() {
    	transform.position = transform.position + new Vector3(0,0,2);
    	gameManager.GetComponent<GameManager>().EnemyPieceMoved();
    }
}
