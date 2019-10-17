using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public int Speed = 7;
    [SerializeField]
    public GameManager gameManager;

    void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        Move(gameManager.ReferenceBallSecondPosition-gameManager.ReferenceBallFirstPosition);
    }

    public void Move(Vector2 Direction)
    {
        BallRigidbody.velocity = Direction.normalized * Speed;
    }
}
