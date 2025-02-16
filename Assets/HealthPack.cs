using UnityEditor;
using UnityEngine;

[System.Serializable]
public class HealthPack
{
    public GameObject healthPackPrefab;
    [Range(0, 100)] public float dropChance;

}

