using System;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private int _remainingEnemies;
    public int RemainingEnemies => _remainingEnemies;
    [SerializeField] private EnemyController[] enemies;

    protected virtual void Awake()
    {
        _remainingEnemies = enemies.Length;
        for (var i = 0; i < enemies.Length; i++)
        {
            enemies[i].OnDeath += () => _remainingEnemies--;
        }
    }
}