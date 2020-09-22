using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingNumbersInitializer : MonoBehaviour
{
    public GameObject prefabNumber;
    [SerializeField] GameObject prefabPlanet;
    float elapsedSeconds = 0;
    float elapsedSecondsBeachBall = 0;

    public float spawnInterval = 3f;
    public float spawnIntervalBeachBall = 6f;

    float MinSpawnInterval = 1f;

  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(BeachBallSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            elapsedSeconds += Time.deltaTime;

            if (elapsedSeconds >= spawnInterval)
            {
                print(spawnInterval);
                Instantiate(prefabNumber, new Vector2(Random.Range(-7f, 7f), 6f), Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);

                elapsedSeconds = 0;
                if (spawnInterval >= MinSpawnInterval)
                {
                    spawnInterval -= .05f;
                }


            }
        }
    }

    IEnumerator BeachBallSpawn()
    {
        while (true)
        {
            elapsedSecondsBeachBall += Time.deltaTime;

            if (elapsedSecondsBeachBall >= spawnIntervalBeachBall)
            {
             
                Instantiate(prefabPlanet, new Vector2(Random.Range(-7f, 7f), 6f), Quaternion.identity);
                yield return new WaitForSeconds(spawnIntervalBeachBall);

                elapsedSecondsBeachBall = 0;
                if (spawnIntervalBeachBall >= MinSpawnInterval)
                {
                    spawnIntervalBeachBall -= .01f;
                }

            }
        }
    }
}
