using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPooling<T> : MonoBehaviour where T : Component
{
    public T ObjectToPool;
    private Queue<T> PooledObject = new Queue<T>();

    #region Singleton
    public static GenericObjectPooling<T> Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }
    #endregion

    public T Get()
    {
        if(PooledObject.Count == 0)
        {
            AddObject(1);
        }
        return PooledObject.Dequeue(); 
    }

    public void ReturnToPool(T DestroyObject)
    {
        DestroyObject.gameObject.SetActive(false);
        PooledObject.Enqueue(DestroyObject);
    }

    public void AddObject(int amount)
    {
        T obj = GameObject.Instantiate(ObjectToPool);
        obj.gameObject.SetActive(true);
        PooledObject.Enqueue(ObjectToPool);
    }
}
