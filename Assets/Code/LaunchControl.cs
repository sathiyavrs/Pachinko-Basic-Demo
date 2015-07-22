using UnityEngine;

public class LaunchControl : MonoBehaviour
{
    public float InitialThrust = 10f;

    private Rigidbody2D _rigidBody;
    private bool _hasLaunched;

    public void Start()
    {
        _hasLaunched = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            Debug.LogError("RigidBody2D not set.");
            enabled = false;
        }
    }

    public void Update()
    {
        if (!_hasLaunched)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hasLaunched = true;
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        _rigidBody.AddForce(new Vector2(0, Random.Range(InitialThrust / 2, InitialThrust * 2)), ForceMode2D.Impulse);
    }
}
