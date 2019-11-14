using UnityEngine;
using UnityEngine.UI;
using BricksBreaker.Data;

public class Brick : MonoBehaviour
{
    [SerializeField]
    public Text BrickText;
    private int Count = 0;
    public BrickData BrickData { get; set; }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Count++;
            Debug.Log(Count + "kere çarptı bana !");
            if (Count == 5)
                BrickPool.Instance.ReturnToPool(this);
        }
    }
}
