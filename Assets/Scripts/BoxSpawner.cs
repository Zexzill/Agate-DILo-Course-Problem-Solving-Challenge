using UnityEngine;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour
{
    public GameObject Box;
    public Transform Canvas;

    private void Start()
    {
        InvokeRepeating("SpawnBoxRandomly", 2, 2);
    }

    private void SpawnBoxRandomly()
    {
        GameObject spawnedBox = Instantiate(Box, Canvas);
        RectTransform boxRectTransform = spawnedBox.GetComponent<RectTransform>();

        int randomPositionX = Random.Range(-120, 120);
        int randomPositionY = Random.Range(-120, 120);
        int randomBoxSizeX = Random.Range(10, 25);
        int randomBoxSizeY = Random.Range(10, 25);

        Vector2 randomedPosition = new Vector2(randomPositionX, randomPositionY);
        Vector2 randomedSize = new Vector2(randomBoxSizeX, randomBoxSizeY);

        boxRectTransform.localPosition = randomedPosition;
        boxRectTransform.sizeDelta = randomedSize;
    }
}
