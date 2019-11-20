using UnityEngine;
using UnityEngine.UI;
using BricksBreaker.Data;
using System.Linq;

public class Brick : MonoBehaviour
{
    [SerializeField]
    public Text BrickText;
    private int amountCollision;
    public BrickData BrickData          { get; set; }
    [SerializeField]
    public InGameManager InGameManager;

    public void Start()
    {
        amountCollision = InGameManager.GameManager.GetValue(BrickData.Id);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            amountCollision--;
            if (amountCollision == 0 || amountCollision < 0)
                BrickPool.Instance.ReturnToPool(this);

            Debug.Log(amountCollision);
        }
    }
}
