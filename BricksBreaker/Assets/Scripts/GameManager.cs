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
    private float AngleReferenceBallList, AngleXReferenceBallList, AngleYReferenceBallList;

    void Start()
    {
        CreateReferenceList();
        ReferenceBallFirstPosition = PlayerBall.transform.position;
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

    private void GetTouchPosition()
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

            }
        }
    }
    public void GetDirectedReferenceBallList()
    {
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {

            ReferenceBallList[i].SetActive(true);
        }
    }

    public void GetAngle()
    {
        AngleReferenceBallList = Mathf.Atan2(ReferenceBallSecondPosition.y - ReferenceBallFirstPosition.y, ReferenceBallSecondPosition.x - ReferenceBallFirstPosition.x);
        AngleXReferenceBallList = Mathf.Cos(AngleReferenceBallList);
        AngleYReferenceBallList = Mathf.Sin(AngleReferenceBallList);


    }
}
