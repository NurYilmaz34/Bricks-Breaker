using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public GameObject ReferenceBall;
    public List<GameObject> ReferenceBallList;
    public InGameManager InGameManager;

    void Start()
    {
        CreateReferenceList();
    }

    private void Update()
    {
        InGameManager.GetTouchPosition();
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
}
