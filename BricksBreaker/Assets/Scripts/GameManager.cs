using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerBall;
    public GameObject ReferenceBall;
    public LayerMask LayerMasks;
    public Ball Ball;
    private List<GameObject> ReferenceBallList;
    private List<Ball> BallList;
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

    void Start()
    {
        CreateReferenceList();
        ReferenceBallFirstPosition = PlayerBall.transform.position;
        Ball.gameManager = this;
    }

    private void Update()
    {
        GetTouchPosition();
    }

    public void CreateReferenceList()
    {
        ReferenceBallList = new List<GameObject>();
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {
            GameObject refernceObj = Instantiate(ReferenceBall, Vector3.zero, Quaternion.identity);
            refernceObj.name = "referenceball_" + i.ToString();
            ReferenceBallList.Add(refernceObj);
            ReferenceBallList[i].SetActive(false);
        }
    }

    public void GetTouchPosition()
    {
        if (Input.touchCount == 1)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                GetAngleReferenceBallList();
                isMoving = false;
            }
            else if (finger.phase == TouchPhase.Moved)
            {
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                GetAngleReferenceBallList();
                isMoving = false;
            }
            else if (finger.phase == TouchPhase.Ended)
            {
                for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
                {
                    ReferenceBallList[i].SetActive(false);
                }
                isMoving = true;

            }
            if (isMoving == true)
            {
                isMoving = false;
                for (int i = 0; i < 1; i++)
                {
                    var Ball = BallPool.Instance.Get();
                    //BallList.Add(Ball);
                    //BallList[i].gameObject.SetActive(true);
                }

            }
        }
    }

    public void GetAngleReferenceBallList()
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
                Collider2D isInsideOfCircle = Physics2D.OverlapCircle(new Vector2(TempXPosition, TempYPosition), ReferenceBallList[i].transform.localScale.x, LayerMasks);

                if (isInsideOfCircle == null)
                {
                    showHelper = true;
                }
                else if (isInsideOfCircle.CompareTag("Wall"))
                {
                    if (!triggerWall)
                    {
                        showHelper = true;
                        AngleValueXReferenceBallList *= -1;
                        triggerWall = true;
                    }
                }
                else if (isInsideOfCircle.CompareTag("Brick"))
                {
                    showHelper = false;
                }
            }

            TempXPosition += AngleValueXReferenceBallList;
            TempYPosition += AngleValueYReferenceBallList;
            ReferenceBallList[i].transform.position = new Vector3(TempXPosition, TempYPosition, 0);

            if (showHelper == true)
                ReferenceBallList[i].SetActive(true);
            else
                ReferenceBallList[i].SetActive(false);
            
        }
    }
}
