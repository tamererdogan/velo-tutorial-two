using UnityEngine;

public class CollactableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        GameplayManager.Instance.Collect(gameObject.tag);
    }
}
