using UnityEngine;
using System.Collections;

public class ShrinkStars : MonoBehaviour
{
    public float RateOfShrink = 0.5f;
    private Vector3 _initialScale;

    public void Start()
    {
        _initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void Respawn()
    {
        var renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            return;

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
        transform.localScale = _initialScale;
    }

    public void BeginShrink()
    {
        StartCoroutine(ShrinkCo());
    }

    private IEnumerator ShrinkCo()
    {
        while (true)
        {
            transform.localScale = new Vector3(transform.localScale.x - RateOfShrink, transform.localScale.y - RateOfShrink, transform.localScale.z);

            if (transform.localScale.x < 0f || transform.localScale.y < 0f)
                break;

            yield return new WaitForEndOfFrame();
        }
        Kill();
        yield break;
    }

    private void Kill()
    {
        var renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            return;

        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
    }
}
