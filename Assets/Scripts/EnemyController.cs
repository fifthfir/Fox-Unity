using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

	public Transform leftPoint, rightPoint;

	private bool movingRight;

	private Rigidbody2D theRB;
	public SpriteRenderer theSR;

	public float moveTime, waitTime;
	private float moveCount, waitCount;

	private Animator anim;


	// Start is called before the first frame update
    void Start()
    {
		theRB = GetComponent<Rigidbody2D>();

		leftPoint.parent = null;
		rightPoint.parent = null;
		movingRight = true;
		moveCount = moveTime;
		waitCount = waitTime;
		anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
		if (moveCount > 0)
		{
			anim.SetBool("isMoving", true);
			moveCount -= Time.deltaTime;

			if (movingRight)
			{
				theSR.flipX = true;
				theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

				if (transform.position.x > rightPoint.position.x)
				{
					movingRight = false;
				}
			}
			else
			{
				theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
				theSR.flipX = false;

				if (transform.position.x < leftPoint.position.x)
				{
					movingRight = true;
				}
			}

			if (moveCount <= 0)
			{
				waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
			}
		}
		else if (waitCount > 0)
		{
			anim.SetBool("isMoving", false);

			waitCount -= Time.deltaTime;
			theRB.velocity = new Vector2(0, theRB.velocity.y);

			if (waitCount <= 0)
			{
				moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);

			}

		}

    }
}
