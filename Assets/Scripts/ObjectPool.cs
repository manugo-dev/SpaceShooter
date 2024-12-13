using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T prefab; 
    [SerializeField] private int poolSize = 10;

    private Queue<T> pool = new Queue<T>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            T poolObject = Instantiate(prefab);
            poolObject.gameObject.SetActive(false);
            pool.Enqueue(poolObject);
        }
    }

    public T GetObject()
    {
        if (pool.Count == 0)
        {
            T poolObject = Instantiate(prefab);
            poolObject.gameObject.SetActive(true);
            return poolObject;
        }

        T pooledObject = pool.Dequeue();
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }

    public void ReleaseObject(T poolObject)

    {

        if (pool.Contains(poolObject))
        {
            Debug.LogWarning("Object is already in the pool.");

        }


        // Verifica si el objeto ya está desactivado antes de ponerlo nuevamente en el pool
        if (poolObject.gameObject.activeInHierarchy)
        {
            poolObject.gameObject.SetActive(false);
            pool.Enqueue(poolObject);
        }
        else
        {
            Debug.LogError("Attempted to release an already deactivated object.");
        }
    }

}