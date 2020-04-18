using UnityEngine;

/// <summary>
/// Spawns asteroid when game starts
/// </summary>
public class AsteroidSpawner : MonoBehaviour 
{
	[SerializeField]
	GameObject prefabAsteroid;
	float radius;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		ScreenUtils.Initialize();
		GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
		radius = asteroid.GetComponent<CircleCollider2D>().radius;
		Destroy(asteroid);

		// asteroid 1 to spawn from the top of the screen
		GameObject asteroid1 = Instantiate(prefabAsteroid) as GameObject;
		Vector3 positionTop = new Vector3(0, ScreenUtils.ScreenTop + radius, -Camera.main.transform.position.z);
		asteroid1.GetComponent<Asteroid>().Initialize(Direction.Down, positionTop);

		// asteroid 2 to spawn from the bottom of the screen
		GameObject asteroid2 = Instantiate(prefabAsteroid) as GameObject;
		Vector3 positionBottom = new Vector3(0, ScreenUtils.ScreenBottom - radius, -Camera.main.transform.position.z);
		asteroid2.GetComponent<Asteroid>().Initialize(Direction.Up, positionBottom);

		// asteroid 3 to spawn from the left of the screen
		GameObject asteroid3 = Instantiate(prefabAsteroid) as GameObject;
		Vector3 positionLeft = new Vector3(ScreenUtils.ScreenLeft - radius, 0, -Camera.main.transform.position.z);
		asteroid3.GetComponent<Asteroid>().Initialize(Direction.Right, positionLeft);

		// asteroid 4 to spawn from the riught of the screen
		GameObject asteroid4 = Instantiate(prefabAsteroid) as GameObject;
		Vector3 positionRight = new Vector3(ScreenUtils.ScreenRight + radius, 0, -Camera.main.transform.position.z);
		asteroid4.GetComponent<Asteroid>().Initialize(Direction.Left, positionRight);
	}
}
