using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class InGameManager : MonoBehaviour
{
    public GameObject PlayerBall;
    public LayerMask LayerMasks;
    public Ball Ball;
    [SerializeField]
    public Vector3 ReferenceBallFirstPosition;
    [SerializeField]
    public Vector3 ReferenceBallSecondPosition;
    private float AngleReferenceBall;
    private float AngleValueXReferenceBallList;
    private float AngleValueYReferenceBallList;
    private float TempXPosition;
    private float TempYPosition;
    private bool showHelper = true;
    private bool triggerWall = false;
    private bool isMoving;
    [SerializeField]
    public GameManager GameManager;

    void Start()
    {
        ReferenceBallFirstPosition = PlayerBall.transform.position;
        Ball.InGameManager = this;
    }

    public void GetTouchPosition()
    {
        if (Input.touchCount == 1)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                SetAngleReferenceBallList();
                isMoving = false;
            }
            else if (finger.phase == TouchPhase.Moved)
            {
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                SetAngleReferenceBallList();
                isMoving = false;
            }
            else if (finger.phase == TouchPhase.Ended)
            {
                for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
                {
                    GameManager.ReferenceBallList[i].SetActive(false);
                }
                isMoving = true;

            }
            if (isMoving == true)
            {
                isMoving = false;
                for (int i = 0; i < 1; i++)
                {
                    var Ball = BallPool.Instance.Get();
                }

            }
        }
    }

    public void SetAngleReferenceBallList()
    {
        AngleReferenceBall = Mathf.Atan2(ReferenceBallSecondPosition.y - ReferenceBallFirstPosition.y, ReferenceBallSecondPosition.x - ReferenceBallFirstPosition.x);
        AngleValueXReferenceBallList = Mathf.Cos(AngleReferenceBall);
        AngleValueYReferenceBallList = Mathf.Sin(AngleReferenceBall);

        TempXPosition = ReferenceBallFirstPosition.x;
        TempYPosition = ReferenceBallFirstPosition.y;

        GetBall();
    }

    public void GetBall()
    {
        showHelper = true;
        triggerWall = false;

        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {
            if (showHelper == true)
            {
                Collider2D isInsideOfCircle = Physics2D.OverlapCircle(new Vector2(TempXPosition, TempYPosition), GameManager.ReferenceBallList[i].transform.localScale.x, LayerMasks);

                if (isInsideOfCircle == null)
                {
                    showHelper = true;
                }
                else if (isInsideOfCircle && isInsideOfCircle.CompareTag("Wall"))
                {
                    if (!triggerWall)
                    {
                        showHelper = true;
                        AngleValueXReferenceBallList *= -1;
                        triggerWall = true;
                    }
                }
                else if (isInsideOfCircle && isInsideOfCircle.CompareTag("Brick"))
                {
                    showHelper = false;
                }
            }

            TempXPosition += AngleValueXReferenceBallList/2f;
            TempYPosition += AngleValueYReferenceBallList/2f;
            GameManager.ReferenceBallList[i].transform.position = new Vector3(TempXPosition, TempYPosition, 0);

            if (showHelper == true)
                GameManager.ReferenceBallList[i].SetActive(true);
            else
                GameManager.ReferenceBallList[i].SetActive(false);

        }
    }

}
