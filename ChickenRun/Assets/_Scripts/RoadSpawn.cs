using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    private int numberOfRoads = 3;

    private float spawnPos;
    [SerializeField] private float roadLength; // Length by z coordinates
    [SerializeField] private GameObject[] roadPrefabs;
    
    private List<GameObject> activeTiles = new List<GameObject>();
   
    [SerializeField] private Transform _player;
    
    private void Start() => RandomTile();

    private void Update() => PositionTile();

    private void RandomTile()
    {
        for (int i = 0; i < numberOfRoads; i++)
        {
            SpawnTile(Random.Range(0, roadPrefabs.Length));
        }
    }

    private void PositionTile()
    {
        if(_player.position.z > spawnPos - (numberOfRoads * roadLength))
            SpawnTile(Random.Range(0, roadPrefabs.Length));
    }

    private void SpawnTile(int roadIndex)
    {
        GameObject nextRoad = Instantiate(roadPrefabs[roadIndex], -transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextRoad);
        spawnPos += roadLength; 
    }
}