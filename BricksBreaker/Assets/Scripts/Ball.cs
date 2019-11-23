using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 15f;
    public Rigidbody2D BallRigidbody;
    [SerializeField]
    public InGameManager InGameManager;

    void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        Move(InGameManager.ReferenceBallSecondPosition-InGameManager.ReferenceBallFirstPosition);
    }

    public void Update()
    {
        SetBallPositionRestrict();
    }

    private void SetBallPositionRestrict()
    {
        float BallXPosition = Mathf.Clamp(gameObject.transform.position.x, -2.6f, 2.6f);
        float BallYPosition = Mathf.Clamp(gameObject.transform.position.y, -4.8f, 4.8f);
        transform.position = new Vector3(BallXPosition, BallYPosition, 0);
    }

    public void Move(Vector2 Direction)
    {
        BallRigidbody.velocity = Direction.normalized * (Mathf.Clamp(Speed, 10f, 15f));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall-down"))
        {
            BallPool.Instance.ReturnToPool(this);
            this.transform.position = InGameManager.GameManager.PlayerBall.transform.position;
        }
    }
    
}
