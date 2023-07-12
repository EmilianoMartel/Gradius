using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public static EnemyWave INSTANCE;
    [SerializeField] WaveData waveData;
    [SerializeField] Vector3 p_position;
    [SerializeField] float enemyNum;
    private int currentWave;
    private bool _activateWave = false;

    //variable change wave
    private int numEnemy;

    //variables spawner
    [SerializeField] GameObject spawnTowerUp;
    [SerializeField] GameObject spawnTowerDown;
    [SerializeField] GameObject spawnShipUp;
    [SerializeField] GameObject spawnShipDown;

    //variables WaveElection
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

    private void Update()
    {

    }

    private IEnumerator WavesShip()
    {
        int waveSeed = Random.Range(0,int.MaxValue);
        for (int i = 0; i <= enemyNum; i++)
        {
            ShipEnemy enemy = Instantiate(waveData.ship, transform.position, Quaternion.identity);
            enemy.SetSeed(waveSeed);
            enemy.DefinePattern();
            numEnemy++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void TowerSpawn()
    {
        Instantiate(waveData.tower,transform.position,Quaternion.identity);
        numEnemy++;
    }

    private void MaxEnemyGenerator()
    {
        enemyNum = Random.Range(waveData.minEnemy,waveData.maxEnemy);
    }

    private void ChangeWave()
    {
        if (waveData.wavesEnemyNum >= waveCount)
        {
            Debug.Log("alo");
        }
        waveCount++;
        RandomGenerationSpawn();
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
                StartCoroutine(WavesShip());
            } else if (wave == 1)
            {
                TowerSpawn();
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
}
