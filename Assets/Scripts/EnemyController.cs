using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage
{
    public event Action OnDeath;
    public event Action<int> OnHealthChange;
    [SerializeField] private GameObject animatedModel;
    [SerializeField] private GameObject ragdollModel;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private int health = 100;
    public int Health => health;
    public bool IsDead => health <= 0;

    private void Awake()
    {
        ragdollModel.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChange?.Invoke(health);
        if (!IsDead) return;
        OnDeath?.Invoke();
        ActivateRagdoll();
    }

    private void ActivateRagdoll()
    {
        CopyTransformData(animatedModel.transform, ragdollModel.transform);
        ragdollModel.SetActive(true);
        animatedModel.SetActive(false);
        mainCollider.enabled = false;
    }

    private void CopyTransformData(Transform sourceTransform, Transform destinationTransform)
    {
        if(sourceTransform.childCount != destinationTransform.childCount) return;

        for (var i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var destination = destinationTransform.GetChild(i);
            destination.position = source.position;
            destination.rotation = source.rotation;
            
            CopyTransformData(source, destination);
        }
    }
}