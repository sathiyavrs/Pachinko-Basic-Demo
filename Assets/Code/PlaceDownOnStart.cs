using UnityEngine;

public class PlaceDownOnStart : MonoBehaviour
{
    public float MaxDistanceCheck = 10f;
    public LayerMask PlatformMask;

    private CircleCollider2D _collider;
    private Vector2 _bottomPoint;

    public void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        if (_collider == null)
        {
            Debug.LogError("Cirle Collider has not been set");
            return;
        }

        _bottomPoint = new Vector2(transform.position.x, transform.position.y) + _collider.offset 
            + new Vector2(0f, -_collider.radius * transform.localScale.y);

        var raycastHit = Physics2D.Raycast(_bottomPoint, -Vector2.up, MaxDistanceCheck, PlatformMask);
        if (!raycastHit)
            return;

        var distanceToMove = raycastHit.point.y - _bottomPoint.y;
        transform.Translate(new Vector3(0, distanceToMove));
    }

}
