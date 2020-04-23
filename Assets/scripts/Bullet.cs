using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	const int bulletLifespan = 2;
	Timer deathTimer;

	/// <summary>
	/// Force to be applied to bullet
	/// </summary>
	/// <value>direction</value>
	public void ApplyForce(Vector2 direction)
	{
		const float magnitude = 5f;
		GetComponent<Rigidbody2D>().AddForce(
			magnitude * direction,
			ForceMode2D.Impulse);
	}

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		deathTimer = gameObject.AddComponent<Timer>();
		deathTimer.Duration = bulletLifespan;
		deathTimer.Run();
	}

	void Update() 
	{
		if (deathTimer.Finished)
		{
			Destroy(gameObject);
		}
	}
}
