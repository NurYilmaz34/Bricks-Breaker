using UnityEngine;
using System.Collections.Generic;
using BricksBreaker.Data;

public class BallDirection : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BallReference;
    private List<GameObject> BallReferenceList;

    void Start()
    {
        BallReferenceList = new List<GameObject>();
        for (int i = 0; i < CommonConstants.NumberOfReferenceBall ; i++)
        {

        }
    }
    
}
