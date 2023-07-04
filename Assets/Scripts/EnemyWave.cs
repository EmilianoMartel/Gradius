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

    private void Start()
    {
        currentWave = 0;
        MaxEnemyGenerator();
        StartCoroutine(Waves());
    }
    private void Update()
    {
        
    }

    private IEnumerator Waves()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            waveData.enemyList.Add(Instantiate(waveData.enemyList[0], transform.position, Quaternion.identity));
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void MaxEnemyGenerator()
    {
        enemyNum = Random.Range(waveData.minEnemy,waveData.enemyList.Count);
    }

    private void ChangeWave()
    {

    }
}
