using UnityEngine;

public class SpawnIfNoChildren : MonoBehaviour
{
    public GameObject spawnedObjectPrefab;
    public float maxZOffset = 1f;
    public float maxYOffset = 1f;
    public float spawnDelay = 1f;
    private float timeSinceLastSpawn = 0f;


    private void Update()
    {
       if (transform.childCount == 0)
        {
            if (timeSinceLastSpawn >= spawnDelay)
            {
                SpawnObject();
                timeSinceLastSpawn = 0f;
            }
            else
            {
                timeSinceLastSpawn += Time.deltaTime;
            }
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f,maxYOffset, maxZOffset);
        GameObject spawnedObject = Instantiate(spawnedObjectPrefab, spawnPosition, Quaternion.identity);
        spawnedObject.transform.parent = transform;
    }
}