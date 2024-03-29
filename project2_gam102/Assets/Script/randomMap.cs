﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{

    public List<GameObject> listGround;
    public List<GameObject> listGroundOld;

    Vector3 endPos; //vi tri cuoi cung
    Vector3 nextPos; //vi tri tiep theo

    int groundLen;

    public float rangeToDestroyObject = 60f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(18.0f, -2.0f, 0.0f);
        GenerateMap();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject) 
        {
            GenerateMap();
        }
        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }
     void GenerateMap()
    {
        for (int i = 0; i < 5; i++)
        {
            float khoangcach = Random.Range(2f, 5f); // khoang cach ngau nhien giua cac block
            nextPos = new Vector3(endPos.x + khoangcach, -2f, 0f);

            //tao so nguyen ngau nhien trong khoang tu a-b, ko bao gom b
            int groundID = Random.Range(0, listGround.Count);

            //tao ra block ban do ngau nhien
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 4; break;
                case 1: groundLen = 9; break;
            }

            endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);
        }
    }
}
