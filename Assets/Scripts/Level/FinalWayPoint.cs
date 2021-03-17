using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinalWayPoint : WayPoint
{
    private GameManager _gameManager;

    protected override void Awake()
    {
        base.Awake();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _gameManager.Restart();
    }
}