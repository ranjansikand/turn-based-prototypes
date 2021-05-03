using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameObject gameManager;
    // public GameObject playerUI;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!(gameManager.GetComponent<GameManager>().PlayerTurn())) {
            selected = false;
        }
    }

    //public GameObject powerupIndicator;
    //powerupIndicator.gameObject.SetActive(true);

    private void OnMouseDown() {
        if (gameManager.GetComponent<GameManager>().PlayerTurn() && !(selected)) {
            GetComponent<CharacterScript>().Move(1);
            gameManager.GetComponent<GameManager>().PlayerPieceMoved();

            selected = true;
        }
    }
}
