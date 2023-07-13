using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Data/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] public TowerEnemy towerUp;
    [SerializeField] public TowerEnemy towerDown;
    [SerializeField] public ShipEnemy ship;
    [SerializeField] public Boss boss;
    [SerializeField] public int minEnemy;
    [SerializeField] public int maxEnemy;
    [SerializeField] public int wavesEnemyNum;
    [SerializeField] public int wavesGameNum;
}
