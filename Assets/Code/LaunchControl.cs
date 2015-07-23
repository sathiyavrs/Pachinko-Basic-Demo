using UnityEngine;
using System.Collections.Generic;

public class LaunchControl : MonoBehaviour
{
    public float InitialThrust = 10f;
    public bool Hardcoding;

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
        EvilThrusts.Add(new Vector2(-0.07713473f, 57.05785f));
        EvilThrusts.Add(new Vector2(0.1569041f, 62.09157f));
        EvilThrusts.Add(new Vector2(-0.2491396f, 35.87185f));
        EvilThrusts.Add(new Vector2(0.3044133f, 47.68961f));
        EvilThrusts.Add(new Vector2(0.3047448f, 42.85242f));
        EvilThrusts.Add(new Vector2(-0.1305335f, 47.99548f));
        EvilThrusts.Add(new Vector2(-0.4897821f, 49.19666f));
        EvilThrusts.Add(new Vector2(0.2731376f, 55.15146f));
        EvilThrusts.Add(new Vector2(-0.3109716f, 50.35185f));

        PrizeworthyThrusts = new List<Vector2>();
        PrizeworthyThrusts.Add(new Vector2(0.3029103f, 33.2245f));
        PrizeworthyThrusts.Add(new Vector2(-0.3647172f, 64.42586f));
        PrizeworthyThrusts.Add(new Vector2(-0.2620234f, 41.03699f));
        PrizeworthyThrusts.Add(new Vector2(0.4430912f, 38.06649f));
        PrizeworthyThrusts.Add(new Vector2(-0.4197791f, 68.92445f));
        PrizeworthyThrusts.Add(new Vector2(-0.3787403f, 42.60497f));
        PrizeworthyThrusts.Add(new Vector2(0.1416063f, 63.3416f));
        PrizeworthyThrusts.Add(new Vector2(0.2953464f, 38.67984f));
        PrizeworthyThrusts.Add(new Vector2(0.4160198f, 41.37711f));
        PrizeworthyThrusts.Add(new Vector2(-0.0180226f, 69.62291f));
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
        if (Hardcoding)
            HardcodedLaunching();
        else
            OrdinaryLaunching();
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

    private void OrdinaryLaunching()
    {
        var thrustY = Random.RandomRange(InitialThrust, InitialThrust * 2);
        var thrustX = Random.Range(-0.5f, 0.5f);
        _rigidBody.AddForce(new Vector2(thrustX, thrustY), ForceMode2D.Impulse);
        Debug.Log(thrustX + " " + thrustY);
    }
}
