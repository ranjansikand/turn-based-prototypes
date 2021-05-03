using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject playerTeam;
	public GameObject enemyTeam;

	private int playerRoster = 3;
	private int enemyRoster = 3;

	private bool playerTurn = false;

	private int playerPiecesMoved = 0;
	private int enemyPiecesMoved = 0;

    // Start is called before the first frame update
    void Start()
    {
    	GeneratePlayerTeam();
    	GenerateEnemyTeam();

    	BeginPlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RosterChange(string deadPiece) {
    	if (deadPiece == "Player") {
    		playerRoster-=1;
    		Debug.Log(deadPiece + " roster: " + playerRoster);
    	} else if (deadPiece == "Enemy") {
    		enemyRoster-=1;
    		Debug.Log(deadPiece + " roster: " + enemyRoster);
    	}
    }

    public void PlayerPieceMoved() {
    	playerPiecesMoved += 1;

    	if (playerPiecesMoved == playerRoster) {
    		EndPlayerTurn();
    	}

    	//Debug.Log("Player moved " + playerPiecesMoved + " piece(s)");
    }

    public void EnemyPieceMoved() {
    	enemyPiecesMoved += 1;

    	if (enemyPiecesMoved == enemyRoster) {
    		BeginPlayerTurn();
    		//Debug.Log("Enemy finished.");
    	}

    	//Debug.Log("Enemy moved " + enemyPiecesMoved + " piece(s)");
    }

    private void EndPlayerTurn() {
    	playerTurn = false;
    	enemyPiecesMoved = 0;
    	Debug.Log("Enemy Turn");
    }

    private void BeginPlayerTurn() {
    	playerTurn = true;
    	playerPiecesMoved = 0;
    	Debug.Log("Player Turn");
    }

    public bool PlayerTurn() {
    	return playerTurn;
    }

    void GeneratePlayerTeam() {
    	for (int i = 0; i < playerRoster; i++) {
    		Instantiate(playerTeam, new Vector3(RandomX(), 1.1f, RandomY()), playerTeam.transform.rotation);
	    }
    }

    void GenerateEnemyTeam() {
    	for (int i = 0; i < enemyRoster; i++) {
	        Instantiate(enemyTeam, new Vector3(-RandomX(), 1.1f, RandomY()), enemyTeam.transform.rotation);
	    }
    }

    int RandomX() {
    	float checker = Random.Range(1, 10);
    	if (checker < 5) {
    		return -5;
    	} else {
    		return -7;
    	}
    }

    int RandomY() {
    	// 1, 3, 5, 7
    	float checker = Random.Range(1, 80);
    	if (checker <= 10) {
    		return 1;
    	} else if (checker > 10 && checker <= 20) {
    		return 3;
    	} else if (checker > 20 && checker <= 30) {
    		return 5;
    	} else if (checker > 30 && checker <= 40) {
    		return 7;
    	} else if (checker > 40 && checker <= 50) {
    		return -1;
    	} else if (checker > 50 && checker <= 60) {
    		return -3;
    	} else if (checker > 60 && checker <= 70) {
    		return -5;
    	} else {
    		return -7;
    	}
    }
}