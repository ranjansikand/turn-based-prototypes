using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
	private Vector3 startingPos;
	private float characterHealth;

	public GameObject opponent;

	public GameObject battleHandler;
	private bool activeTurn;

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
    	activeTurn = battleHandler.GetComponent<BattleHandler>().playerTurn;
    	GetComponent<EntityScript>().UpdateHealth(characterHealth);
        if (characterHealth <= 0) {
        	Debug.Log("Character Died");
        }
    }

    public void Attack() {
    	if (activeTurn){
	    	Debug.Log("Attack button pressed");
	    	dodged = false;
	    	blocking = false;

	    	float attackDamage = GetComponent<EntityScript>().attackDamage;

	    	if (Random.Range(1, 10) == 7) {
	    		attackDamage *= 1.5f;
	    		Debug.Log("Critical Hit!");
	    	}

	    	opponent.GetComponent<EnemyAI>().TakeDamage(attackDamage);
	    	Invoke("EndTurn", 1.5f);
	    }
    }

    public void Dodge() {
    	if (activeTurn) {
    		blocking = false;
	    	Debug.Log("Dodge button pressed");
	
	    	if (Random.Range(1, 10) < GetComponent<EntityScript>().dodgeChance) {
	    		Debug.Log("Successful dodge!");
	    		dodged = true;
	    	}
	    	Invoke("EndTurn", 1.5f);
	    }
    }

    public void Block() {
    	if (activeTurn) {
    		dodged = false;
	    	Debug.Log("Block button pressed");
	    	blocking = true;
	    	Invoke("EndTurn", 1.5f);
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
    	Debug.Log("HP: " + characterHealth);
    }

    private void EndTurn() {
    	battleHandler.GetComponent<BattleHandler>().EndPlayerTurn();
    }
}
