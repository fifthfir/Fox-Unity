using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    public static CheckpointsController instance;

	private Checkpoint[] checkpoints;

	public Vector3 spawnPoint;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		checkpoints = FindObjectsOfType<Checkpoint>();
		spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

	}

	public void DeactivateCheckpoints(Checkpoint besides)
	{
		foreach (Checkpoint cp in checkpoints) // for (int i = 0; i < checkpoints.Length; i++)
		{
			cp.resetCheckpoint();  // checkpoints[i].resetCheckpoint();
		}

	}

	public void SetSpawnPoint(Vector3 newSpawnPoint)
	{
		spawnPoint = newSpawnPoint;
	}
}
