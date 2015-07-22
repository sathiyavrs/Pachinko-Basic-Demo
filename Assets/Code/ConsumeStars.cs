using UnityEngine;
using System.Collections;
using System;

public class ConsumeStars : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        var script = other.GetComponent<ShrinkStars>();

        if (script == null)
            return;

        script.BeginShrink();
    }
}

