using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
            spriteRenderer.color = Color.green;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
            spriteRenderer.color = Color.magenta;
        }
    }

    /// <summary>
    /// Initialize asteroid in specific direction
    /// </summary>
    /// <param name="direction"></param>
    public void Initialize(Direction direction, Vector3 position)
    {
        // set asteroid position
        transform.position = position;

        // set random angle based on position
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        float angle;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = -105 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        StartMoving(angle);

    }

    /// <summary>
    /// applies an impulse force to the asteroid with the given angle
    /// </summary>
    /// <param name="angle">angle info</param>
    public void StartMoving(float angle)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 0.2f;
        const float MaxImpulseForce = 0.7f;

        // apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    /// <summary>
    /// Called when an asteroid collides with a bullet
    /// </summary>
    /// <value>coll</value>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            // destroy the bullet
            Destroy(coll.gameObject);

            if (transform.localScale.x < 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                // half the scale of the asteroid and the radius
                Vector3 localScale = transform.localScale;
                localScale.z = -Camera.main.transform.localScale.z;
                localScale.x /= 2;
                localScale.y /= 2;

                transform.localScale = localScale;

                CircleCollider2D collider = transform.GetComponent<CircleCollider2D>();
                collider.radius /= 2;

                // create 2 new asteroids half the size of the original with random direction and impulse force
                GameObject smallerAsteroid1 = Instantiate<GameObject>(this.gameObject, transform.position, Quaternion.identity);
                GameObject smallerAsteroid2 = Instantiate<GameObject>(this.gameObject, transform.position, Quaternion.identity);

                smallerAsteroid1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                smallerAsteroid2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
            }
        }
    }
}
