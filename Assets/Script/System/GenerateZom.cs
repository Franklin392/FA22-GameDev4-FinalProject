using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZom : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();

    public GameObject CarPrefab1;
    public GameObject CarPrefab2;
    public GameObject CarPrefab3;
    public GameObject CarPrefab4;

    public Transform[] spawnPoints;
    public float minDelay = 1f;
    public float maxDelay = 20f;
    public bool FirstRound;
    void Start()
    {
        prefabList.Add(CarPrefab1);
        prefabList.Add(CarPrefab2);
        prefabList.Add(CarPrefab3);
        prefabList.Add(CarPrefab4);

        FirstRound = true;
        StartCoroutine(SpawnCar_Start());

    }
    void Update()
    {
        if (FirstRound == true)
        {
            SpawnCar_WithoutBumb();
        }

        if (FirstRound == false)
        {
            SpawnCar();
        }

    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            Debug.Log("有跑车");
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);


            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            int prefabIndex = Random.Range(0, 4);
            Instantiate(prefabList[prefabIndex], spawnPoint.position, spawnPoint.rotation);

        }



    }
    IEnumerator SpawnCar_WithoutBumb()
    {
        Debug.Log("有车");
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);


        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        int prefabIndex = Random.Range(1, 3);
        Instantiate(prefabList[prefabIndex], spawnPoint.position, spawnPoint.rotation);
    }
    IEnumerator SpawnCar_Start()
    {
        SpawnCar_WithoutBumb();
        FirstRound = true;
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnCar());
    }
}
