using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    //SINGLETON
    public static PathManager Instance { get; private set; }

    //PATH GENERATION
    [SerializeField]
    float pathSize = 40f;

    [SerializeField]
    GameObject pathPrefab;

    GameObject pathHolder;

    List<GameObject> paths = new List<GameObject>();

    //SINGLETON
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //PATH GENERATION
    void Start()
    {
        pathHolder = new GameObject("Environment");

        GameObject pathOne = Instantiate(
            pathPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity,
            pathHolder.transform
        );

        paths.Add(pathOne);
    }

    void FixedUpdate()
    {
        float velocity = GameplayManager.Instance.speed * Time.deltaTime;
        pathHolder.transform.position -= new Vector3(0, 0, velocity);
    }

    public void GeneratePath()
    {
        if (paths.Count != 2)
        {
            GameObject pathTwo = Instantiate(
                pathPrefab,
                paths[0].transform.position + new Vector3(0, 0, pathSize),
                Quaternion.identity,
                pathHolder.transform
            );
            paths.Add(pathTwo);
            return;
        }

        paths[0].transform.position += new Vector3(0, 0, pathSize * 2);
        paths.Reverse();
    }
}
