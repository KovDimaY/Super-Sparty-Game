using UnityEngine;
using System.Collections;

public class ExtraLife : MonoBehaviour {

	public int lifeValue = 1;
	public bool taken = false;
	public GameObject explosion;

	// if the player touches the extra life, it has not already been taken, and the player can move (not dead or victory)
	// then take the extra life
	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.tag == "Player" ) && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
		{
			// mark as taken so doesn't get taken multiple times
			taken=true;

			// if explosion prefab is provide, then instantiate it
			if (explosion)
			{
				Instantiate(explosion,transform.position,transform.rotation);
			}

			// do the player collect extra life thing
			other.gameObject.GetComponent<CharacterController2D>().CollectExtraLife(lifeValue);

			// destroy the extra life
			DestroyObject(this.gameObject);
		}
	}

}
