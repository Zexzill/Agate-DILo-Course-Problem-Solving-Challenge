using UnityEngine;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Box;
    private Dictionary<string, GameObject> _boxDictionary = new Dictionary<string, GameObject>();
    public Transform Canvas;
    public float SpawnInterval = 1f;
    
    //total spawned digunakan untuk memberi index pada nama gameobject, contohnya box1, box2, box3, dst
    private int _totalSpawnedBox = 0;

    private void Start()
    {
        InvokeRepeating("BoxPooling", SpawnInterval, SpawnInterval);
    }

    private void BoxPooling()
    {
        for (int i = 0; i < _boxDictionary.Count; i++)
        {
            if (_boxDictionary.ContainsKey($"box {i}"))
            {
                GameObject objToSpawn = _boxDictionary[$"box {i}"].gameObject;

                if (!objToSpawn.activeSelf)
                {
                    Vector2 point = GetOutsideCircleRadiusPoint();

                    objToSpawn.transform.localPosition = new Vector3(point.x, point.y);
                    objToSpawn.SetActive(true);

                    return;
                }
            }
        }

        InstantiateBox();
    }

    private void InstantiateBox()
    {
        GameObject spawnedBox = Instantiate(Box, Canvas);
        spawnedBox.name = $"box {_totalSpawnedBox}";
        _totalSpawnedBox++;

        _boxDictionary.Add(spawnedBox.name, spawnedBox);

        RectTransform boxRectTransform = spawnedBox.GetComponent<RectTransform>();

        Vector2 point = GetOutsideCircleRadiusPoint();
        
        int randomBoxSizeX = Random.Range(10, 25);
        int randomBoxSizeY = Random.Range(10, 25);

        Vector2 randomedPosition = new Vector2(point.x, point.y);
        Vector2 randomedSize = new Vector2(randomBoxSizeX, randomBoxSizeY);

        boxRectTransform.localPosition = randomedPosition;
        boxRectTransform.sizeDelta = randomedSize;
    }

    private Vector2 GetOutsideCircleRadiusPoint()
    {
        float areaSize = 70;
        float offset = 120;

        float ratio = areaSize / offset;
        float radius = Mathf.Sqrt(Random.Range(ratio * ratio, 1f)) * offset;

        Vector2 circlePosition = new Vector2(Circle.transform.position.x, Circle.transform.position.y);
        Vector3 point = (circlePosition + Random.insideUnitCircle.normalized) * radius;

        //apabila posisi spawn di luar area, maka acak kembali untuk mendapat posisi box didalam area
        if(point.x > 120)
        {
            point.x = Random.Range(-offset, areaSize);
            point.y = Random.Range(-120, 120);
        }
        else if(point.x < -120)
        {
            point.x = Random.Range(-areaSize, offset);
            point.y = Random.Range(-120, 120);
        }

        if(point.y > 120)
        {
            point.x = Random.Range(-120, 120);
            point.y = Random.Range(-offset, areaSize);
        }
        else if(point.y < -120)
        {
            point.x = Random.Range(-120, 120);
            point.y = Random.Range(-areaSize, offset);
        }

        return point;
    }
}