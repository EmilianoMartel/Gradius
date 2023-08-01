using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] WaveData waveData;
    [SerializeField] Vector3 p_position;
    [SerializeField] float enemyNum;

    [SerializeField] AudioSource normalMusic;
    [SerializeField] AudioSource bossMusic;

    //variable change wave
    private List<Enemy> spawnedEnemies = new List<Enemy>();

    //variables spawner
    [SerializeField] GameObject spawnTowerUp;
    [SerializeField] GameObject spawnTowerDown;
    [SerializeField] GameObject spawnShipUp;
    [SerializeField] GameObject spawnShipDown;
    private Vector3 spawnShipPoint;
    private Vector3 spawnTowerPoint;

    //variables WaveElection
    private int currentWave;
    private int waveCount;

    private bool waveFinish = false;

    public void Start()
    {
        currentWave = 0;
        spawnedEnemies = new List<Enemy>();
        RandomGenerationSpawn();
    }

    //Function Spawn Ship Enemy
    private IEnumerator WavesShip()
    {
        int waveSeed = Random.Range(0,int.MaxValue);
        for (int i = 0; i <= enemyNum; i++)
        {
            ShipEnemy enemy = Instantiate(waveData.ship, spawnShipPoint, Quaternion.identity);
            enemy.SetSeed(waveSeed);
            enemy.DefinePattern();
            enemy.enemyKill += EnemyKilled;
            spawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(0.5f);
        }
    }

    //Function Spawn Tower Enemy
    private void TowerSpawn(string upOrDown)
    {
        if(upOrDown == "UP")
        {
            TowerEnemy enemy = Instantiate(waveData.towerUp, spawnTowerPoint, Quaternion.identity);
            enemy.enemyKill += EnemyKilled;
            spawnedEnemies.Add(enemy);
        }
        else if(upOrDown == "DOWN")
        {
            TowerEnemy enemy = Instantiate(waveData.towerDown, spawnTowerPoint, Quaternion.identity);
            enemy.enemyKill += EnemyKilled;
            spawnedEnemies.Add(enemy);
        }
    }

    private void MaxEnemyGenerator()
    {
        enemyNum = Random.Range(waveData.minEnemy,waveData.maxEnemy);
    }

    private void ChangeWave()
    {
        if (!waveFinish)
        {
            if (waveData.wavesEnemyNum <= currentWave)
            {
                SpawnBoss();
            }
            else
            {
                currentWave++;
                RandomGenerationSpawn();
            }
        }        
    }

    private void CallSpawn()
    {
        int wave;
        for (int i = 0; i <= waveCount; i++)
        {
            wave = Random.Range(0, 2);
            if (wave == 0)
            {
                MaxEnemyGenerator();
                PointSpawnShipSelection();
            } else if (wave == 1)
            {
                PointSpawnTowerSelection();
            }
        }
    }

    private void RandomGenerationSpawn()
    {
        if (currentWave <= 3)
        {
            waveCount = Random.Range(1,3);
        }
        else
        {
            waveCount = Random.Range(2, currentWave);
        }
        CallSpawn();
    }

    public void EnemyKilled(Enemy enemy)
    {
        spawnedEnemies.Remove(enemy);
        enemy.enemyKill -= EnemyKilled;
        if (spawnedEnemies.Count <= 0)
        {
            ChangeWave();
        }
    }

    private void SpawnBoss()
    {
        normalMusic.Stop();
        bossMusic.Play();
        Instantiate(waveData.boss, transform.position, Quaternion.identity);
        waveFinish = true;
    }

    //Point Spawn Selection for Enemy Ship
    private void PointSpawnShipSelection()
    {
        int randomSpawn = Random.Range(0, 3);
        if (randomSpawn == 0)
        {
            spawnShipPoint = transform.position;
        }
        else if (randomSpawn == 1)
        {
            spawnShipPoint = spawnShipUp.transform.position;
        }
        else
        {
            spawnShipPoint = spawnShipDown.transform.position;
        }
        StartCoroutine(WavesShip());
    }

    //Point Spawn Selection Tower
    private void PointSpawnTowerSelection()
    {
        int randomSpawn = Random.Range(0,4);
        if(randomSpawn == 0)
        {
            spawnTowerPoint = spawnShipUp.transform.position;
            TowerSpawn("UP");
        }
        else if(randomSpawn == 1)
        {
            spawnTowerPoint = spawnTowerUp.transform.position;
            TowerSpawn("UP");
        }
        else if (randomSpawn == 2)
        {
            spawnTowerPoint = spawnTowerDown.transform.position;
            TowerSpawn("DOWN");
        }
        else
        {
            spawnTowerPoint = spawnShipDown.transform.position;
            TowerSpawn("DOWN");
        }
    }
}
