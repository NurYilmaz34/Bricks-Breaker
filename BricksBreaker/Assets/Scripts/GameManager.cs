using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public Ball PlayerBall;
    public GameObject ReferenceBall;
    private List<GameObject> ReferenceBallList;
    private Vector3 firstTouch;
    private Vector3 secondTouch;
    private Vector3 tempTouch;


    void Start()
    {
        firstTouch = PlayerBall.transform.position;
        tempTouch = firstTouch;
        CreateReferenceList();
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
                //tempTouch = Camera.ScreenToWorldPoint(new Vector3());
                ShowReferenceBallList();
            }
            else if (finger.phase == TouchPhase.Moved)
            {

            }
            else if (finger.phase == TouchPhase.Ended)
            {

            }
        }
    }

    public void ShowReferenceBallList()
    {
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall; i++)
        {
            ReferenceBallList[i].SetActive(true);
        }
    }

    public void GetAngle()
    {

    }
}
