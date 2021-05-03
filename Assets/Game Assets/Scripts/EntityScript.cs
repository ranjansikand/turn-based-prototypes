using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityScript : MonoBehaviour
{
	public float characterHealth = 100f;
	public float characterShield = 0.3f;  // amount of damage not blocked
	public float attackDamage = 15f;
	public float dodgeChance = 3f;  // represents a 30% chance

	public Text healthText;

	public void UpdateHealth(float health) {
		healthText.text = health.ToString();
	}
}
