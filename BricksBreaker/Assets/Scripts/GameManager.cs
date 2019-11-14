using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public GameObject ReferenceBall;
    public BrickData[] BrickDataArray           { get; set; }
    public List<GameObject> ReferenceBallList   { get; set; }
   
    void Start()
    {
        CreateReferenceList();
        CreateBrickDataArray();
    }
    
    public void CreateReferenceList() 
    {
        ReferenceBallList = new List<GameObject>();
        for (int i = 0; i < CommonConstants.NumberOfHelperBall; i++)
        {
            GameObject refernceObj = Instantiate(ReferenceBall, Vector3.zero, Quaternion.identity);
            refernceObj.name = "referenceball_" + i.ToString();
            ReferenceBallList.Add(refernceObj);
            ReferenceBallList[i].SetActive(false);
        }
    }

    public void CreateBrickDataArray()
    {
        BrickDataArray = new BrickData[CommonConstants.NumberOfBrick];

        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            int valueOfValue = Random.Range(1,10);
            int y = Random.Range(-3, 3);
            transform.position = new Vector3(0, y, 0);
            int orderOfOrder = (int)transform.position.y;
            BrickDataArray[i] = new BrickData(valueOfValue, orderOfOrder);
        }

    }
    
}
