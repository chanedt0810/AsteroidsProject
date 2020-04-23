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
        // apply impulse force to get game object moving
        const float MinImpulseForce = 0.5f;
        const float MaxImpulseForce = 1f;

        transform.position = position;

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
    /// <value>col</value>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
