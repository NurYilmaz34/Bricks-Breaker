using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public float Speed = 8f;
    private Collider2D Collider2D;
    [SerializeField]
    public InGameManager InGameManager;

    void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
    }

    public void Start()
    {
        Move(InGameManager.ReferenceBallSecondPosition-InGameManager.ReferenceBallFirstPosition);
    }

    public void Move(Vector2 Direction)
    {
        BallRigidbody.velocity = Direction.normalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall-down"))
            BallPool.Instance.ReturnToPool(this);
        if (collision.collider.CompareTag("Ball"))
            Collider2D.isTrigger = false;
    }
}
