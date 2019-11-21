using UnityEngine;
using UnityEngine.UI;
using BricksBreaker.Data;

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

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(BrickData.Order.x, BrickData.Order.y, 100, 20), BrickData.Value.ToString());
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            amountCollision--;
            if (amountCollision == 0 || amountCollision < 0)
                BrickPool.Instance.ReturnToPool(this);

            Debug.Log("collision " + amountCollision + " value" + InGameManager.GameManager.GetValue(BrickData.Id));
        }
    }

    
}
