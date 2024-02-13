using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject levelContainer;

    [SerializeField]
    GameObject[] prefabs;

    Vector3[,] spawnPoints =
    {
        { new Vector3(-2.5f, 0, 2.5f), new Vector3(0, 0, 2.5f), new Vector3(2.5f, 0, 2.5f) },
        { new Vector3(-2.5f, 0, 7.5f), new Vector3(0, 0, 7.5f), new Vector3(2.5f, 0, 7.5f) },
        { new Vector3(-2.5f, 0, 12.5f), new Vector3(0, 0, 12.5f), new Vector3(2.5f, 0, 12.5f) },
        { new Vector3(-2.5f, 0, 17.5f), new Vector3(0, 0, 17.5f), new Vector3(2.5f, 0, 17.5f) },
        { new Vector3(-2.5f, 0, 22.5f), new Vector3(0, 0, 22.5f), new Vector3(2.5f, 0, 22.5f) },
        { new Vector3(-2.5f, 0, 27.5f), new Vector3(0, 0, 27.5f), new Vector3(2.5f, 0, 27.5f) },
        { new Vector3(-2.5f, 0, 32.5f), new Vector3(0, 0, 32.5f), new Vector3(2.5f, 0, 32.5f) },
        { new Vector3(-2.5f, 0, 37.5f), new Vector3(0, 0, 37.5f), new Vector3(2.5f, 0, 37.5f) },
    };

    public void GenerateLevel()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(
                    prefabs[Random.Range(0, prefabs.Length)],
                    spawnPoints[i, j],
                    Quaternion.identity,
                    levelContainer.transform
                );
            }
        }
    }
}
