using UnityEngine;
using UnityEngine.UI;
using BricksBreaker.Data;
using TMPro;

public class Brick : MonoBehaviour
{
    private TextMeshPro ValueText;
    private int amountCollision;
    public BrickData BrickData          { get; set; }
    [SerializeField]
    public InGameManager InGameManager;

    public void Awake()
    {
        ValueText = GetComponentInChildren<TextMeshPro>();
    }
    public void Start()
    {
        amountCollision = InGameManager.GameManager.GetValue(BrickData.Id);
        ValueText.SetText(amountCollision.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            amountCollision--;
            ValueText.SetText(amountCollision.ToString());
            if (amountCollision == 0 || amountCollision < 0)
                BrickPool.Instance.ReturnToPool(this);
        }

        if (collision.collider.CompareTag("Wall-down"))
            BrickPool.Instance.ReturnToPool(this);
    }

    
}
