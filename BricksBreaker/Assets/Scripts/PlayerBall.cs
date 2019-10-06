using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBall : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public Transform BallTransform;
    private Vector3 FirstPosition;
    private Vector3 LastPosition;
    private Vector3 BallPosition;
    


    private void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
        BallTransform = GetComponent<Transform>();
        BallPosition = transform.position;
    }

    private void GetTouchPosition()
    {
        if(Input.touchCount == 1)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {

            }
            else if(finger.phase == TouchPhase.Moved)
            {

            }
            else if(finger.phase == TouchPhase.Ended)
            {

            }
        }
    }
}
