using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public Transform BallTransform;
    private Vector2 FirstPosition;
    private Vector2 LastPosition;
    private Vector2 BallPosition;

    private void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
        BallTransform = GetComponent<Transform>();
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
