using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public bool taken = false;
	public GameObject explosion;

	// if the player touches the chek point, it has not already been taken, and the player can move (not dead or victory)
	// then save his position for the next respawn 
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

			// do the player save his position
			other.gameObject.GetComponent<CharacterController2D>().SavePosition();

			
		}
	}

}
