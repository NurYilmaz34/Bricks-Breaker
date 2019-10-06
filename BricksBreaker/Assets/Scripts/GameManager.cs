using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public PlayerBall PlayerBall;
    public GameObject ReferenceBall;
    private List<GameObject> ReferenceBallList;


    void Start()
    {
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

}
