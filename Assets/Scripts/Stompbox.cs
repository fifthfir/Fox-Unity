using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{
	public GameObject deathEffect;
	[Range(0, 100)]public float chanceToDrop;
	public GameObject collectable;

	// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy"))
		{
			Debug.Log("Hit Enemy");
			Instantiate(deathEffect, other.transform.position, other.transform.rotation);
			PlayerController.instance.StompBounce();

			other.transform.parent.gameObject.SetActive(false);

			float dropSelect = Random.Range(0, 100);
			if (dropSelect <= chanceToDrop)
			{
				Instantiate(collectable, other.transform.position, other.transform.rotation);
			}

			AudioManager.instance.PlaySFX(3);
		}
	}
}
