using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] private float spawnRate = 20f;
    private float nextSpawnTimer;
    private float maxBoundX;
    private float maxBoundY;
    private GameObject obj;

    private void Start()
    {
        maxBoundX = GameManager.Instance.maxBoundX;
        maxBoundY = GameManager.Instance.maxBoundY;
        nextSpawnTimer = spawnRate;
    }
    private void Update()
    {
        if(Time.time > nextSpawnTimer)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
            SpawnPowerUp();
            nextSpawnTimer = Time.time + spawnRate;
            
        }

    }

    private void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(3, maxBoundX-3), Random.Range(3, maxBoundY-3), 0);
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        obj =  Instantiate(powerUpPrefabs[powerUpIndex], spawnPosition, Quaternion.identity);
    }

}
