using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text spawnedEnemiesScore;
    [SerializeField] AudioClip spawnedEnemySFX;
    [SerializeField] Transform EnemiesParentTransform;

    int score;


    void Start()
    {
        spawnedEnemiesScore.text = score.ToString();

        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = EnemiesParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemiesScore.text = score.ToString();
    }
}
