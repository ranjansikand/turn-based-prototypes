using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
	public ParticleSystem explosionParticle;
    public Vector3 piecePosition;

    public int health = 3;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        piecePosition = transform.position;

        if (health <= 0) {
            DeathAnimation();
        }
    }

    public void DeathAnimation() {
    	Destroy(gameObject);
    	Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.GetComponent<GameManager>().RosterChange(gameObject.tag);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Enemy") {
            if (gameObject.tag == "Player" && collision.collider.tag == "Enemy") {
                Move(-1);
                health-=1;
            } else if (gameObject.tag == "Enemy" && collision.collider.tag == "Player") {
                Move(1);
                health-=1;
            }
        }
    }

    public void Move(int direction) {
        transform.position = transform.position + direction * (new Vector3(2,0,0));
    }
}
