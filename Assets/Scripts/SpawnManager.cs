using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalList;
    [SerializeField] GameManager manager; 

    [SerializeField] float spawnRadius = 20f;

    [SerializeField] float startDelay = 2f;
    [SerializeField] float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); 
    }

    public Vector3 getSpawnLocation(float radius) 
    {
        float xPos = Random.Range(-radius, radius);
        float zPos = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(xPos, 2)) * (Random.Range(0, 2) * 2 - 1);

        return new Vector3(xPos, 0, zPos);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalList.Length);
        Vector3 spawnPosition = getSpawnLocation(spawnRadius); // ABSTRACTION
        GameObject temp = Instantiate(animalList[animalIndex], spawnPosition, Quaternion.identity);
        temp.GetComponent<AnimalController>().setManager(manager);
    }
}
