using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Data/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] public List<Enemy> enemyList;
    [SerializeField] public int minEnemy;
    [SerializeField] public int wavesNum;
}
