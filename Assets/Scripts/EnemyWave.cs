using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public static EnemyWave INSTANCE;
    [SerializeField] WaveData waveData;
    [SerializeField] Vector3 p_position;
    [SerializeField] float enemyNum;

    //variable change wave
    private int numEnemy;

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

    //Lo convertimos en un Singelton
    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(this);
        }
        else
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        currentWave = 0;
        numEnemy = 0;
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
            numEnemy++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    //Function Spawn Tower Enemy
    private void TowerSpawn(string upOrDown)
    {
        if(upOrDown == "UP")
        {
            Instantiate(waveData.towerUp, spawnTowerPoint, Quaternion.identity);
        }
        else if(upOrDown == "DOWN")
        {
            Instantiate(waveData.towerDown, spawnTowerPoint, Quaternion.identity);
        }
        numEnemy++;
    }

    private void MaxEnemyGenerator()
    {
        enemyNum = Random.Range(waveData.minEnemy,waveData.maxEnemy);
    }

    private void ChangeWave()
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

    public void EnemyKilled()
    {
        numEnemy--;
        if(numEnemy <= 0)
        {
            ChangeWave();
        }
    }

    private void SpawnBoss()
    {
        Instantiate(waveData.boss, transform.position, Quaternion.identity);
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
