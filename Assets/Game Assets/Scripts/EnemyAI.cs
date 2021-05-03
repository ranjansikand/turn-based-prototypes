using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	private Vector3 startingPos;
	private float characterHealth;

	public GameObject battleHandler;
	public GameObject opponent;
	private bool activeTurn;
	private bool moveMade = false;

	public float waitTime = 2.5f;

	bool blocking = false;
	bool dodged = false;

	float incomingDamage;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        characterHealth = GetComponent<EntityScript>().characterHealth;
    }

    // Update is called once per frame
    void Update()
    {
    	activeTurn = !(battleHandler.GetComponent<BattleHandler>().playerTurn);
        if (characterHealth <= 0) {
        	Debug.Log("Character Died");
        }

        GetComponent<EntityScript>().UpdateHealth(characterHealth);

        int moveType = Random.Range(1, 30);
        if (activeTurn && !moveMade) {
        	if (moveType < 10) {
        		Invoke("Attack", waitTime);
        		Debug.Log("Enemy attacks!");
        	} else if ((moveType >= 10) && (moveType < 20)) {
        		Invoke("Dodge", waitTime);
        		Debug.Log("Enemy dodges");
        	} else {
        		Invoke("Block", waitTime);
        		Debug.Log("Enemy blocks");
        	}
	    	moveMade = true;
	    	Invoke("EndTurn", waitTime);
        }
    }

    public void Attack() {
    	if (activeTurn){
    		dodged = false;
    		blocking = false;
	    	float attackDamage = GetComponent<EntityScript>().attackDamage;

	    	if (Random.Range(1, 10) == 7) {
	    		attackDamage *= 1.5f;
	    		Debug.Log("Critical Hit!");
	    	}
		    opponent.GetComponent<PlayerScripts>().TakeDamage(attackDamage);
	    }
    }

    public void Dodge() {
    	if (activeTurn) {
    		blocking = false;
	    	if (Random.Range(1, 10) < GetComponent<EntityScript>().dodgeChance) {
	    		Debug.Log("Successful dodge!");
	    		dodged = true;
	    	}
	    }
    }

    public void Block() {
    	if (activeTurn) {
    		dodged = false;
	    	blocking = true;
	    }
    }

    public void TakeDamage(float damage) {
    	if (blocking) {
    		incomingDamage = damage * GetComponent<EntityScript>().characterShield;
    		blocking = false;
    	} else if (dodged) {
    		incomingDamage = 0;
    		dodged = false;
    	} else {
    		incomingDamage = damage;
    	}

    	characterHealth -= incomingDamage;
    	Debug.Log("Enemy HP: " + characterHealth);
    }

    private void EndTurn() {
    	battleHandler.GetComponent<BattleHandler>().BeginPlayerTurn();
    	Invoke("UpdateMove", 1);
    }

    private void UpdateMove() {
    	moveMade = false;
    }
}
