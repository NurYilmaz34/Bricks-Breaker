using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject ReferenceBall;
    public List<BrickData> BrickDataList        { get; set; }
    public List<GameObject> ReferenceBallList   { get; set; }
    [SerializeField]
    private Brick[] Bricks;


    void Start()
    {
        CreateReferenceList();
        //CreateBrickDataList();
        GetBrick();
        SetBrickData();
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

    //public void CreateBrickDataList()
    //{
    //    //BrickDataList = new List<BrickData>();

    //    for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
    //    {
    //        //int value = Random.Range(1, 10);
    //        //int yPos = Random.Range(-3, 3);
    //        //Vector3 order = new Vector3(0, yPos, 0);
    //        //BrickDataList.Add(new BrickData(i, value, order));
    //    }
    //}

    public void GetBrick()
    {
        Bricks = new Brick[CommonConstants.NumberOfBrick];
        BrickDataList = new List<BrickData>();
        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            var Brick = BrickPool.Instance.Get();
            int value = Random.Range(1, 6);
            int yPos = Random.Range(-3, 5);
            Vector3 order = new Vector3(0, yPos, 0);
            BrickDataList.Add(new BrickData(i, value, order));
            Brick.transform.position = order;
            Brick.name = "brick_" + i.ToString();
            Bricks[i] = Brick;
            Bricks[i].gameObject.SetActive(true);
        }
    }

    public void SetBrickData()
    {
        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            Bricks[i].BrickData = BrickDataList.First(lstBrickData => lstBrickData.Id == i);
        }
    }
    
    public int GetValue(int id)
    {
        return BrickDataList[id].Value;
    }
}
