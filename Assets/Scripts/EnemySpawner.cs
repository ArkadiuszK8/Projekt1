using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public float[] enemySlots;

    public int defaultSlotIndex;

    public GameObject[] enemiesPrefabs;

    public float spawnPropability;

    public float timeToSpawn;

    public float timeToSpawnMultiplier;

    public float enemiesSpeed;

    public float enemiesSpeedMultiplier;

    public Text score;

    private int currentScore;

    private float currentTimeToSpawn;

    private float currentEnemiesSpeed;

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;

        currentEnemiesSpeed = enemiesSpeed;

        StartCoroutine(SpawnEnemies());

        currentScore = 0;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {

            yield return new WaitForSeconds(timeToSpawn);

            for (int i = 0; i < enemySlots.Length; i++)
            {
                float random = Random.Range(0f, 1f);

                if (random < spawnPropability)
                {
                    GameObject randomEnemy = Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)]);

                    randomEnemy.transform.position = new Vector2(enemySlots[i], transform.position.y);

                    randomEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.down * currentEnemiesSpeed;
                }
            }

            currentTimeToSpawn *= timeToSpawnMultiplier;

            currentEnemiesSpeed *= enemiesSpeedMultiplier;

            currentScore++;

            score.text = "Score: " + currentScore;
        }
    }
}
