using UnityEngine;

public class ObjectTypeHolder : MonoBehaviour
{
    public Resources.ObjectType Type;

    public void Start()
    {
        if(GetComponent<Collider2D>() == null)
        {
            Debug.LogError("Add a collider to each damaging object!");
            return;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<LaunchControl>() == null)
            return;

        if (Type == Resources.ObjectType.Evil)
            LevelScript.Instance.KillPlayer();
        else if (Type == Resources.ObjectType.Prize)
            LevelScript.Instance.Win();
    }
}