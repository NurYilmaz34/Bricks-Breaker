using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;

public class GameManager : MonoBehaviour
{
    public GameObject ReferenceBall;
    public List<BrickData> BrickDataList        { get; set; }
    public List<GameObject> ReferenceBallList   { get; set; }
   
    void Start()
    {
        CreateReferenceList();
        CreateBrickDataList();
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

    public void CreateBrickDataList()
    {
        BrickDataList = new List<BrickData>();

        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            int value = Random.Range(1, 10);
            int yPos = Random.Range(-3, 3);
            Vector3 order = new Vector3(0, yPos, 0);
            BrickDataList.Add(new BrickData(i, value, order));
        }
    }

    //public int GetBrickValue()
    //{
    //    return ;
    //}
    
}
