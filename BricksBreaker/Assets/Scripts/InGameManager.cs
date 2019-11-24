﻿using System.Collections;
using UnityEngine;
using BricksBreaker.Data;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    public Ball Ball;
    [SerializeField]
    public Brick Brick;
    [SerializeField]
    public GameObject PlayerBall;
    [SerializeField]
    public LayerMask LayerMasks;
    [SerializeField]
    public GameManager GameManager;
    [SerializeField]
    public Vector3 ReferenceBallFirstPosition    { get; set; }  
    [SerializeField]
    public Vector3 ReferenceBallSecondPosition   { get; set; }
    private float AngleReferenceBall             { get; set; }
    private float AngleValueXReferenceBallList   { get; set; }
    private float AngleValueYReferenceBallList   { get; set; }
    private float TempXPosition                  { get; set; }
    private float TempYPosition                  { get; set; }
    private bool showHelper = true;
    private bool triggerWall = false;
    private bool isMoving;
    private bool isScroll = false;
    private bool isAngle;

    void Start()
    {
        ReferenceBallFirstPosition = PlayerBall.transform.position;
        Ball.InGameManager = this;
        Brick.InGameManager = this;
    }

    private void Update()
    {
        HelperControl();
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
                for (int i = 0; i < CommonConstants.HelperBall; i++)
                {
                    GameManager.ReferenceBallList[i].SetActive(false);
                }
                isMoving = true;
                
            }

            if (isMoving == true && isAngle == true)
            {
                StartCoroutine(SetSpawnBall());
            }
            else
                return;
        }
    }
    
    private void HelperControl()
    {
        if (!GameManager.IsBallOver())
        {
            for (int i = 0; i < CommonConstants.HelperBall; i++)
            {
                GameManager.ReferenceBallList[i].SetActive(false);
            }
            isScroll = true;
        }
        else
        {
            GetTouchPosition();
            
            if (GameManager.inactiveBall == CommonConstants.NumberOfSpawnBall && isScroll == true)
            {
                isScroll = false;
                GameManager.ScrollControl();
            }
        }   
    }
    
    public IEnumerator SetSpawnBall()
    {
        for (int i = 0; i < CommonConstants.NumberOfSpawnBall; i++)
        {
            yield return new WaitForSeconds(0.03f);
            GameManager.BallList[i].gameObject.SetActive(true);
            GameManager.BallList[i].Move(ReferenceBallSecondPosition - ReferenceBallFirstPosition);
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

    private void HelperBallAngleControl()
    {
        if (AngleReferenceBall < 0.03f)
        {
            showHelper = false;
            isScroll = false;
            isAngle = false;
        }
    }

    public void GetBall()
    {
        showHelper = true;
        triggerWall = false;

        for (int i = 0; i < CommonConstants.HelperBall; i++)
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
            HelperBallAngleControl();
            GameManager.ReferenceBallList[i].transform.position = new Vector3(TempXPosition, TempYPosition, 0);

            if (showHelper == true)
            {
                isAngle = true;
                GameManager.ReferenceBallList[i].SetActive(true);
            }
                
            else
                GameManager.ReferenceBallList[i].SetActive(false);
        }
    }

}
