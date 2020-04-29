using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	const int bulletLifespan = 2;
	Timer deathTimer;

	/// <summary>
	/// Force to be applied to bullet in given direction
	/// </summary>
	/// <value>direction</value>
	public void ApplyForce(Vector2 direction)
	{
		const float magnitude = 3f;
		GetComponent<Rigidbody2D>().AddForce(
			magnitude * direction,
			ForceMode2D.Impulse);
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// create and run death timer
		deathTimer = gameObject.AddComponent<Timer>();
		deathTimer.Duration = bulletLifespan;
		deathTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update() 
	{
		// kill bullet when timer is done
		if (deathTimer.Finished)
		{
			Destroy(gameObject);
		}
	}
}
