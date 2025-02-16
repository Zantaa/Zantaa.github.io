using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObjects/Waves", order = 1)]

public class Waves : ScriptableObject
{
    [field: SerializeField]
    public GameObject[] EnemiesAlive { get; private set; }
    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }
    [field: SerializeField]
    public float EnemiesInQue { get; private set; }

    [field: SerializeField]
    public float EnemiesHealth { get; private set; }

    [field: SerializeField]
    public float EnemiesAttackDamage { get; private set; }

}
