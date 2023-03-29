using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public Transform LIMIT;
    public GameObject prefab;
    public float prefabSpacing = 1f;
    public Transform origin;
    public Vector2Int gridDimensions = new Vector2Int(8, 8);
    public float spawnHeight;
    public Vector3 respawnPosition = new Vector3(0f, -1f, 0f);
    public Vector3 startPosition;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    public player ps;
    void Start()
    {
        startPosition = origin.position;
        // Spawn prefabs in a grid
        for (int x = 0; x < gridDimensions.x; x++)
        {

            for (int z = 0; z < gridDimensions.y; z++)
            {
                Vector3 spawnPosition = new Vector3(startPosition.x + (x * prefabSpacing), startPosition.y, startPosition.z + (z * prefabSpacing));
                spawnHeight = spawnPosition.y;
                GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnedPrefabs.Add(newPrefab);
            }
        }
        
    }

    void Update()
    {
        // Check if all spawned prefabs have been destroyed
        bool allDestroyed = true;
        foreach (GameObject prefab in spawnedPrefabs)
        {
            if (prefab != null)
            {
                allDestroyed = false;
                break;
            }
        }

        // Respawn all prefabs if they have been destroyed
        if (allDestroyed)
        {
            // Clear the list of spawned prefabs
            spawnedPrefabs.Clear();

            ps.LookDown = true;

            // Spawn new prefabs at a lower height
            for (int x = 0; x < gridDimensions.x; x++)
            {
                for (int z = 0; z < gridDimensions.y; z++)
                {
                    Vector3 spawnPosition = new Vector3(startPosition.x + (x * prefabSpacing), spawnHeight-2, startPosition.z + (z * prefabSpacing));
                    
                    GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
                    spawnedPrefabs.Add(newPrefab);
                }
            }
            spawnHeight = spawnHeight - 2;
            LIMIT.position = new Vector3(LIMIT.position.x, LIMIT.position.y - 1f, LIMIT.position.z);
        }
    }
}