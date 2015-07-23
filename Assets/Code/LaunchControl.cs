using UnityEngine;
using System.Collections.Generic;

public class LaunchControl : MonoBehaviour
{
    public float InitialThrust = 10f;

    private Rigidbody2D _rigidBody;
    private bool _hasLaunched;

    // Hardcoding
    private List<Vector2> EvilThrusts;
    private List<Vector2> PrizeworthyThrusts;

    public void Start()
    {
        _hasLaunched = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            Debug.LogError("RigidBody2D not set.");
            enabled = false;
        }

        // Hardcoding
        EvilThrusts = new List<Vector2>();
        EvilThrusts.Add(new Vector2(0.2f, 56f));
        EvilThrusts.Add(new Vector2(0, 42.3f));
        EvilThrusts.Add(new Vector2(0.4f, 59));
        EvilThrusts.Add(new Vector2(-0.3f, 51.4f));
        EvilThrusts.Add(new Vector2(-0.5f, 41.4f));
        EvilThrusts.Add(new Vector2(0.3f, 55.3f));
        EvilThrusts.Add(new Vector2(-0.2f, 35.1f));
        EvilThrusts.Add(new Vector2(0, 59.8f));
        EvilThrusts.Add(new Vector2(-0.2f, 68.4f));
        
        PrizeworthyThrusts = new List<Vector2>();
        PrizeworthyThrusts.Add(new Vector2(0.3f, 67f));
        PrizeworthyThrusts.Add(new Vector2(-0.1f, 65.4f));
        PrizeworthyThrusts.Add(new Vector2(0.3f, 45.1f));
        PrizeworthyThrusts.Add(new Vector2(0, 45.3f));
        PrizeworthyThrusts.Add(new Vector2(-0.5f, 53.8f));
        PrizeworthyThrusts.Add(new Vector2(-0.2f, 44.8f));
        PrizeworthyThrusts.Add(new Vector2(-0.5f, 50.9f));
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
        HardcodedLaunching();
    }

    private void HardcodedLaunching()
    {
        if (LevelScript.Instance.NumberOfLives != 1)
        {
            var vector = EvilThrusts[Random.Range(0, EvilThrusts.Count - 1)];
            Debug.Log("Evil " + vector);
            _rigidBody.AddForce(vector, ForceMode2D.Impulse);
        }
        else
        {
            var vector = PrizeworthyThrusts[Random.Range(0, PrizeworthyThrusts.Count - 1)];
            _rigidBody.AddForce(vector, ForceMode2D.Impulse);
            Debug.Log("Good " + vector);
        }
    }

    private void OrdinaryLaunching(out float thrustY, out float thrustX)
    {
        thrustY = Random.RandomRange(InitialThrust, InitialThrust * 2);
        thrustX = Random.Range(-0.5f, 0.5f);
        _rigidBody.AddForce(new Vector2(thrustX, thrustY), ForceMode2D.Impulse);
    }
}
