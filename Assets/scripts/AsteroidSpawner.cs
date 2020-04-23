using UnityEngine;

/// <summary>
/// Spawns asteroid when game starts
/// </summary>
public class AsteroidSpawner : MonoBehaviour 
{
	[SerializeField]
	GameObject prefabAsteroid;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		// save asteroid radius
		GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
		CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
		float asteroidRadius = collider.radius;
		Destroy(asteroid);

		// get asteroid script
		Asteroid script = asteroid.GetComponent<Asteroid>();

		// calculate screen width and height
		float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
		float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

		// asteroid 1 to spawn from the top of the screen
		asteroid = Instantiate<GameObject>(prefabAsteroid);
		script = asteroid.GetComponent<Asteroid>();
		script.Initialize(Direction.Down,
			new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
				ScreenUtils.ScreenTop + asteroidRadius));

		// asteroid 2 to spawn from the bottom of the screen
		asteroid = Instantiate<GameObject>(prefabAsteroid);
		script = asteroid.GetComponent<Asteroid>();
		script.Initialize(Direction.Up,
			new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
				ScreenUtils.ScreenBottom - asteroidRadius));

		// asteroid 3 to spawn from the left of the screen
		asteroid = Instantiate<GameObject>(prefabAsteroid);
		script = asteroid.GetComponent<Asteroid>();
		script.Initialize(Direction.Right,
			new Vector2(ScreenUtils.ScreenLeft - asteroidRadius,
				ScreenUtils.ScreenBottom + screenHeight / 2));

		// asteroid 4 to spawn from the riught of the screen
		asteroid = Instantiate<GameObject>(prefabAsteroid);
		script = asteroid.GetComponent<Asteroid>();
		script.Initialize(Direction.Left,
			new Vector2(ScreenUtils.ScreenRight + asteroidRadius,
				ScreenUtils.ScreenBottom + screenHeight / 2));
	}
}
