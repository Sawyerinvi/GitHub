using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 10f;
    private float countDown = 2f;

    private void Update()
    {
        if(countDown <= 0f)
        {
            SpawnWave();
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        Debug.Log("Wave incoming");
    }
}
