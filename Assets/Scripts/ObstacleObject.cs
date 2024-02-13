using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
        GameplayManager.Instance.HitObstacle();
    }
}
