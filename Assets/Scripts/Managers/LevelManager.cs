using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject levelItems;

    Vector3[,] spawnPoints =
    {
        { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) },
        { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) }
    };

    // Vector3[][] spawnPoints = {
    //     {new Vector3(0,0,0), new Vector3(0,0,0),new Vector3(0,0,0)}
    // };

    // string[] selects = { "c", "o", "f" };

    public void GenerateLevel()
    {
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                // objects[Random.Range(0, 3)];
                // levelItems.gameObject
                // Debug.Log(i + "-" + j + "-" + objects[Random.Range(0, 3)]);
            }
        }
    }
}
