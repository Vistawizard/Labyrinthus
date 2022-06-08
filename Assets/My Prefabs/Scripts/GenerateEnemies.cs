using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject thePlayer;
    public int maxEnemies;
    public int enemyCount;
    public float spawnRadius = 7f;

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        yield return new WaitForSeconds(delay);
        while (enemyCount < maxEnemies)
        {
            Vector3 spawnPos = thePlayer.transform.position; //Spawning an enemy
            spawnPos += Random.insideUnitSphere.normalized * spawnRadius;
            spawnPos.y = 0.29f;
            Instantiate(theEnemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            enemyCount += 1;
        }
    }

    
}
