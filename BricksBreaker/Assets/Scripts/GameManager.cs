using System.Collections.Generic;
using UnityEngine;
using BricksBreaker.Data;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private bool IsScrollBreak = false;
    [SerializeField]
    public Brick[] Bricks;
    [SerializeField]
    public GameObject PlayerBall;
    public GameObject ReferenceBall;
    public List<Ball> BallList                  { get; set; }
    public List<BrickData> BrickDataList        { get; set; }
    public List<GameObject> ReferenceBallList   { get; set; }
    

    void Start()
    {
        CreateReferenceList();
        GetBrickArray();
        SetBrickData();
        GetBallList();
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
    
    public void GetBrickArray()
    {
        Bricks = new Brick[CommonConstants.NumberOfBrick];
        BrickDataList = new List<BrickData>();
        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            var Brick = BrickPool.Instance.Get();
            int value = Random.Range(5, 11);
            int yPos = Random.Range(-1, 5);
            int xPos = Random.Range(-2,2);
            Vector3 order = new Vector3(xPos, yPos, 0);
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
    
    public void GetBallList()
    {
        BallList = new List<Ball>();
        for (int i = 0; i < CommonConstants.NumberOfSpawnBall; i++)
        {
            var Ball = BallPool.Instance.Get();
            Ball.transform.position = PlayerBall.transform.position;
            BallList.Add(Ball);
            BallList[i].gameObject.SetActive(false);
        }
    }
    
    public bool IsGameOver()
    {
        for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
        {
            if (Bricks[i].gameObject.activeInHierarchy == true)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsBallOver()
    {
        for (int i = 0; i < CommonConstants.NumberOfSpawnBall; i++)
        {
            if (BallList[i].gameObject.activeInHierarchy == true)
            {
                return false;
            }
        }
        return true;
    }

    public void ScrollControl()
    {
        if (!IsGameOver() && IsBallOver())
        {
            IsScrollBreak = true;
        }
    }

    private void BrickScroll()
    {
        if (IsScrollBreak == true)
        {
            for (int i = 0; i < CommonConstants.NumberOfBrick; i++)
            {
                Bricks[i].BrickData.Order -= new Vector3(0, 1, 0);
                Bricks[i].transform.position = Bricks[i].BrickData.Order;
                
            }
            IsScrollBreak = false;
        }
    }

}
