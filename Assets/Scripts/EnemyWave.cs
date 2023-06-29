using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] WaveData waveData;
    [SerializeField] Vector3 p_position;

    private void Start()
    {
        p_position = transform.position;
        StartCoroutine(Waves());
    }

    private IEnumerator Waves()
    {
        for (int i = 0; i < waveData.enemyList.Count; i++)
        {
            Instantiate(waveData.enemyList[i], p_position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
