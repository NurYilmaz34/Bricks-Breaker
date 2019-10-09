using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public Ball PlayerBall;
    public GameObject ReferenceBall;
    private List<GameObject> ReferenceBallList;
    private Vector3 ReferenceBallFirstPosition;
    private Vector3 ReferenceBallSecondPosition;
    private float AngleReferenceBall;
    private float AngleXReferenceBallList;
    private float AngleYReferenceBallList;
    private float TempX;
    private float TempY;

    void Start()
    {
        CreateReferenceList();
        ReferenceBallFirstPosition = PlayerBall.transform.position;
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
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(finger.position);
                GetDirectedReferenceBallList();
            }
            else if (finger.phase == TouchPhase.Moved)
            {
                ReferenceBallSecondPosition = Camera.main.ScreenToWorldPoint(finger.position);
                GetDirectedReferenceBallList();
            }
            else if (finger.phase == TouchPhase.Ended)
            {
                for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
                {
                    Move(ReferenceBallSecondPosition - ReferenceBallFirstPosition);
                }
                
            }
        }
    }

    private void Move(Vector2 force)
    {
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {
            ReferenceBallList[i].GetComponent<Rigidbody2D>().velocity = force.normalized*5;
        }
    }

    public void GetDirectedReferenceBallList()
    {
        AngleReferenceBall = Mathf.Atan2(ReferenceBallSecondPosition.y - ReferenceBallFirstPosition.y, ReferenceBallSecondPosition.x - ReferenceBallFirstPosition.x);
        AngleXReferenceBallList = Mathf.Cos(AngleReferenceBall);
        AngleYReferenceBallList = Mathf.Sin(AngleReferenceBall);

        TempX = ReferenceBallFirstPosition.x;
        TempY = ReferenceBallFirstPosition.y;

        GetReferenceBall();
    }

    public void GetReferenceBall()
    {
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {
            TempX += AngleXReferenceBallList;
            TempY += AngleYReferenceBallList;

            ReferenceBallList[i].transform.position = new Vector3(TempX, TempY, 0);
            ReferenceBallList[i].SetActive(true);
        }
    }

    private void CheckOfRaycastHit()
    {

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
    //    {
    //        if (collision.collider.name == "Wall-right")
    //        {
    //             ReferenceBallList[i].transform.position = new Vector3(-ReferenceBall.transform.position.x, ReferenceBall.transform.position.y, 0);
    //        }
    //        else if (collision.collider.name == "Wall-left")
    //        {
                
    //        }
    //        else if (collision.collider.name == "Wall-up")
    //        {

    //        }
    //        else if (collision.collider.name == "Wall-down")
    //        {

    //        }
    //    }
        
    //}

}
