using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneController : MonoBehaviour
{
	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerHealthController.instance.currentHealth = 0;
			AudioManager.instance.PlaySFX(8);

			UIController.instance.UpdateHealthDisplay();
			LevelManager.instance.RespawnPlayer();
		}

	}
}
