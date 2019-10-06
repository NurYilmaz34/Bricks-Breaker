using System.Collections.Generic;
using UnityEngine;

abstract class GenericObjectPooling<T> where T : MonoBehaviour
{
    public T ObjectToPool;
    private Queue<T> PooledObject = new Queue<T>();

    #region Singleton
    public static GenericObjectPooling<T> Instance;

    public void Awake()
    {
        Instance = this;
    }
    #endregion

    public T Get()
    {
        if(PooledObject.Count == 0)
        {
            AddObject();
        }
        return PooledObject.Dequeue(); 
    }

    public void ReturnToPool(T DestroyObject)
    {
        DestroyObject.gameObject.SetActive(false);
        PooledObject.Enqueue(DestroyObject);
    }

    public void AddObject()
    {
        T obj = GameObject.Instantiate(ObjectToPool);
        obj.gameObject.SetActive(false);
        PooledObject.Enqueue(ObjectToPool);
    }
}
