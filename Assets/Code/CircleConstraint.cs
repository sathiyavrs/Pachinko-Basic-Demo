using System;
using UnityEngine;

public class CircleConstraint : MonoBehaviour
{
    [Range(0,1)]
    public float Multiplier = 0.7f;

    private Rigidbody2D _rigidBody;

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            Debug.LogError("RigidBody2D component not set.");
            return;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        var collider = other.GetComponent<CircleCollider2D>();
        if (collider == null)
            return;

        if (collider.GetComponent<BoundsScript>() == null)
            return;

        PerformVelocityCalculations(collider);
        PerformRotationCalculations();
    }

    private void PerformVelocityCalculations(CircleCollider2D collider)
    {
        var centerOfCircle = new Vector2(collider.transform.position.x + collider.offset.x * transform.localScale.x, collider.transform.position.y + collider.offset.y * transform.localScale.y);

        var center = new Vector2(transform.position.x, transform.position.y);

        var direction = center - centerOfCircle;
        var theta = Resources.AngleWithRightAntiClockwise(direction);
        var velocity = _rigidBody.velocity;

        Resources.ShiftVectorByAngleAnticlockwise(ref velocity, theta);
        velocity.x *= -1 * Multiplier;
        Resources.ShiftVectorByAngleAnticlockwise(ref velocity, -theta);
        _rigidBody.velocity = velocity;
    }

    private void PerformRotationCalculations()
    {

    }
}
