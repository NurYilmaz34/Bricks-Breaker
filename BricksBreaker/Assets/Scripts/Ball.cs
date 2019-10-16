using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public int Speed = 7;
    public GameManager GameManager;

    void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        Move(GameManager.ReferenceBallSecondPosition-GameManager.ReferenceBallFirstPosition);
    }

    public void Move(Vector2 Direction)
    {
        BallRigidbody.velocity = Direction.normalized * Speed;
    }
}
