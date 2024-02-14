using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
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

    public void GenerateLevel(bool isFirstLevel = false)
    {
        Transform levelContainerTransform = transform.Find("LevelContainer");
        if (levelContainerTransform == null)
        {
            levelContainerTransform = new GameObject("LevelContainer").transform;
        }
        else
        {
            while (true)
            {
                Transform childTransform = levelContainerTransform.GetChild(0);
                childTransform.SetParent(ObjectPoolManager.Instance.transform);
                childTransform.gameObject.SetActive(false);
                if (levelContainerTransform.childCount == 0)
                    break;
            }
        }

        levelContainerTransform.SetParent(transform, false);
        string[] objectNames = ObjectPoolManager.Instance.GetPrefabNames();
        List<GameObject> rowObjects = new List<GameObject>();
        for (int i = 0; i < 8; i++)
        {
            if (isFirstLevel && i < 3)
                continue;

            rowObjects.Clear();
            for (int j = 0; j < 3; j++)
            {
                string objectName = objectNames[Random.Range(0, objectNames.Length)];
                GameObject item = ObjectPoolManager.Instance.FindOrCreate(objectName);
                item.transform.position = spawnPoints[i, j];
                item.transform.SetParent(levelContainerTransform.transform, false);
                item.SetActive(true);
                rowObjects.Add(item);
            }

            bool isRowClose =
                rowObjects[0].name == rowObjects[1].name
                && rowObjects[1].name == rowObjects[2].name
                && rowObjects[2].name == "CloseObstacle(Clone)";

            if (isRowClose)
            {
                int randIndex = Random.Range(0, 3);
                rowObjects[randIndex].transform.SetParent(ObjectPoolManager.Instance.transform);
                rowObjects[randIndex].transform.gameObject.SetActive(false);
            }
        }
    }
}
