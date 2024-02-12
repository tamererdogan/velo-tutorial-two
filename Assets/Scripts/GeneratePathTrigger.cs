using UnityEngine;

public class GeneratePathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        PathManager.Instance.GeneratePath();
    }
}
