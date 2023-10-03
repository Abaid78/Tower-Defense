using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpowner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWave = 5f;
    private float countdown=2f;
    public int waveNumber = 1;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpwanEnemy();
            yield return new WaitForSeconds(1f);
        }
    }
    void SpwanEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
