using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private readonly Queue<GameObject> _pool = new Queue<GameObject>();

    public GameObject Get()
    {
        if (_pool.Count == 0)
            AddObjects(1);
        return _pool.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        _pool.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        var newObject = Instantiate(prefab);
        newObject.GetComponent<IPoolable>().Pool = this;
        newObject.SetActive(false);
        _pool.Enqueue(newObject);
    }
}