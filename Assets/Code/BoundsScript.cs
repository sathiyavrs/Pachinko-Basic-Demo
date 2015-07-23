using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    private CircleCollider2D _collider;

    public void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _collider = GetComponent<CircleCollider2D>();
        if(_collider == null)
        {
            Debug.LogError("Circular bounds doesn't have circular geometry");
            return;
        }
    }
}
