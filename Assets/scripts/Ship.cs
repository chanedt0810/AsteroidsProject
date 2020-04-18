using UnityEngine;

/// <summary>
/// Move the ship
/// </summary>
public class Ship : MonoBehaviour
{
    Rigidbody2D shipRigidBody2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 5;
    const float RotateDegreesPerSecond = 30;
    float shipColliderRadius;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // set the rigid body of the ship when game starts
        shipRigidBody2D = GetComponent<Rigidbody2D>();
        // get the radius of the circle collider
        shipColliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");

        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }

            transform.Rotate(Vector3.forward, rotationAmount);

            // Adjust the thrust direction 
            Vector3 degrees = transform.eulerAngles;
            float radiansX = degrees.x * Mathf.Deg2Rad;
            float radiansY = degrees.y * Mathf.Deg2Rad;
            thrustDirection = new Vector2(Mathf.Cos(radiansX), Mathf.Sin(radiansY));
        }
    }

    /// <summary>
    /// apply thrust force and direction to the game object
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            shipRigidBody2D.AddRelativeForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
    }

    /// <summary>
    /// functionality for when the game object becomes invisible
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;        

        if (position.x - shipColliderRadius < ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        else if (position.x + shipColliderRadius > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }

        if (position.y - shipColliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        else if (position.y + shipColliderRadius > ScreenUtils.ScreenTop)
        {
            position.y = -position.y;
        }

        transform.position = position;
    }
}
