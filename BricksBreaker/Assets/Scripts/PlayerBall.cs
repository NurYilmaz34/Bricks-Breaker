using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBall : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;

    private void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
    }

    
}
