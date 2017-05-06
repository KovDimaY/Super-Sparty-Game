using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public float timeWaiting = 1f; //time of activation of the teleport
	public bool active = true;
	public GameObject explosion;
    public GameObject newPosition;

    // if the player touches the teleport, it is active, and the player can move (not dead or victory)
    // then teleport the player
    void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.tag == "Player" ) && (active) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
		{
			// make it not active for the time of activation
			active = false;

			// if explosion prefab is provide, then instantiate it
			if (explosion)
			{
				Instantiate(explosion,transform.position,transform.rotation);
			}

            // do the teleportation           
            other.gameObject.GetComponent<CharacterController2D>().TeleportPlayer(timeWaiting, newPosition.transform.localPosition);
            StartCoroutine(Activization());
        }
	}

    IEnumerator Activization()
    {
        // After waiting tell the GameManager to teleport the player
        yield return new WaitForSeconds(timeWaiting + 1.0f);

        //make teleport active again
        this.active = true;
    }

}
