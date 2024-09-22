using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public GameObject enemyPrefab;
   private float spawnRange= 9;
   public int enemyCount;
   public int waveNumber= 1;
   public GameObject powerupPrefab;
    void Start()
    {
        SpawnEnemyWawe(waveNumber);
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        Instantiate(powerupPrefab, GenerateSpawnPosition(),powerupPrefab.transform.rotation);    
    }

   
    void Update()
    {
        // int enemyCount = FindObjectsOfType<Enemy>().Length;
        //if(enemyCount == 0 && enemyCount<10){
        //waveNumber++;
        //SpawnEnemyWawe(waveNumber);
        //}

        var gameObject1 = Instantiate(powerupPrefab,GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private UnityEngine.Vector3 GenerateSpawnPosition(){
        float spawnPosX= Random.Range(-spawnRange, spawnRange);
        float spawnPosZ= Random.Range(-spawnRange, spawnRange);
        UnityEngine.Vector3 randomPos= new UnityEngine.Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
     void SpawnEnemyWawe(int enemiesToSpawn){
      
      for (int i =0; i <enemiesToSpawn; i++){
        Instantiate(enemyPrefab, GenerateSpawnPosition(),
        enemyPrefab.transform.rotation);
      }
        
    }
}
