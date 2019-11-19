using System;
using UnityEngine;

namespace BricksBreaker.Data
{
    public class BrickData
    {
        public int Id        { get; set; }
        public int Value     { get; set; }
        public Vector3 Order { get; set; }

        public BrickData(int id, int value, Vector3 order)
        {
            Id = id;
            Value = value;
            Order = order;
        }
    }
}

