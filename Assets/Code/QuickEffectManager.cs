using UnityEngine;
using System.Collections;

public class QuickEffectManager : MonoBehaviour
{
    public float TimeToLive = 0.8f;

    public void Start()
    {
        StartCoroutine(KillCo());
    }

    private IEnumerator KillCo()
    {
        yield return new WaitForSeconds(TimeToLive);

        Destroy(gameObject);
        yield break;
    }
}
