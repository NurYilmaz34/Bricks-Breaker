using UnityEngine;
using UnityEngine.UI;
using BricksBreaker.Data;

public class Brick : MonoBehaviour
{
    [SerializeField]
    public Text BrickText;
    private int amount = 0;
    public BrickData BrickData          { get; set; }
    public InGameManager InGameManager  { get; set; }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            //amount = InGameManager.GameManager.BrickDataList.;
            amount++;
            Debug.Log(amount + "kere çarptı !");
            if (amount == 5)
                BrickPool.Instance.ReturnToPool(this);
        }
    }
}
