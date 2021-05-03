using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
	public bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1, 100) > 50) {
        	BeginPlayerTurn();
        } else {
        	EndPlayerTurn();
        }
    }

    public void BeginPlayerTurn() {
    	playerTurn = true;
    	Debug.Log("Begin Player Turn");
    }

    public void EndPlayerTurn() {
    	playerTurn = false;
    	Debug.Log("Begin Enemy Turn");
    }
}
