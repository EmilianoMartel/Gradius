using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] WaveData waveData;
    [SerializeField] Vector3 p_position;
    [SerializeField] float enemyNum;
    private int currentWave;
    private bool _activateWave = false;
    private List<Enemy> _enemyList = new List<Enemy>();

    //variables spawner
    [SerializeField] GameObject spawnTowerUp;
    [SerializeField] GameObject spawnTowerDown;
    [SerializeField] GameObject spawnShipUp;
    [SerializeField] GameObject spawnShipDown;

    //variables WaveElection
    private int waveCount;

    private void Start()
    {
        currentWave = 0;
        RandomGenerationSpawn();
    }

    private void Update()
    {

    }

    private IEnumerator WavesShip()
    {
        for (int i = 0; i <= enemyNum; i++)
        {
            _enemyList.Add(Instantiate(waveData.ship, transform.position, Quaternion.identity));
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void TowerSpawn()
    {
        Instantiate(waveData.tower,transform.position,Quaternion.identity);
    }

    private void MaxEnemyGenerator()
    {
        enemyNum = Random.Range(waveData.minEnemy,waveData.maxEnemy);
    }

    private void ChangeWave()
    {

    }

    private void CallSpawn()
    {
        int wave;
        for (int i = 0; i <= waveCount; i++)
        {
            wave = Random.Range(0, 1);
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
}
