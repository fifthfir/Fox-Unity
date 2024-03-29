using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

	public Image heart1, heart2, heart3;

	public Sprite heartFull, heartEmpty, heartHalf;

	public Text gemText;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		UpdateGemCount();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void UpdateHealthDisplay()
	{
		heart1.sprite = heartFull;
		heart2.sprite = heartFull;
		heart3.sprite = heartFull;

		switch(PlayerHealthController.instance.currentHealth)
		{
			case 5:
				heart3.sprite = heartHalf;
				break;
			case 4:
				heart3.sprite = heartEmpty;
				break;
			case 3:
				heart3.sprite = heartEmpty;
				heart2.sprite = heartHalf;
				break;
			case 2:
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				break;
			case 1:
				heart1.sprite = heartHalf;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				break;
			case 0:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				break;
		}
	}

	public void UpdateGemCount()
	{
		gemText.text = LevelManager.instance.gemsCollected.ToString();
	}
}
