﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObjectSpawner : MonoBehaviour
{
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject chest;

    public int no1;
    public int no2;
    public int no3;
    public int no4;
    public int no5;
    public int noEnemy1;
    public int noEnemy2;
    public int noEnemy3;
    public int noChest;

    public float xSize;
    public float zSize;
    public float Timer;

    private int j = 0;
    private int k = 0;
    public NavMeshSurface navMeshSurface;

    private List<Vector3> usedPoints;

    // Start is called before the first frame update
    void Start()
    {
        usedPoints = new List<Vector3>();
        GenerateObjects();
        navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f && k < noEnemy1)
        {
            GenerateEnemy(enemy1);
            Timer = 3f;
            k ++;
        }

        if (Timer <= 0f && j < noEnemy2)
        {
            GenerateEnemy(enemy2);
            GenerateEnemy(enemy3);
            Timer = 10f;
            j ++;
        }     
    }

    void GenerateObject(GameObject go, int amount)
    {
        if (go == null) return;
  
        for(int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(go);

            Vector3 randomPoint = GetRandomPoint();
            usedPoints.Add(randomPoint);
            tmp.gameObject.transform.position = new Vector3(randomPoint.x, tmp.transform.position.y, randomPoint.z);
        }
    }

    void GenerateEnemy(GameObject go)
    {
        if (go == null) return;
  
        // for(int i = 0; i < amount; i++)
        // {
            GameObject tmp = Instantiate(go);

            Vector3 randomPoint = GetRandomPoint();
            usedPoints.Add(randomPoint);
            tmp.gameObject.transform.position = new Vector3(randomPoint.x, tmp.transform.position.y, randomPoint.z);
            // i++;
        // }
    }

    void GenerateObjects()
    {
        GenerateObject(rock1, no1);
        GenerateObject(rock2, no2);
        GenerateObject(rock3, no3);
        GenerateObject(rock4, no4);
        GenerateObject(rock5, no5);
        GenerateObject(chest, noChest);
    }

    Vector3 GetRandomPoint()
    {
        int xRandom = 0;
        int zRandom = 0;
           
        // xRandom = (int)Random.Range(col.bounds.min.x, col.bounds.max.x);
        // zRandom = (int)Random.Range(col.bounds.min.z, col.bounds.max.z);
        xRandom = (int)Random.Range(0.0f, xSize);
        zRandom = (int)Random.Range(0.0f, zSize);

        Vector3 tempVector = new Vector3(xRandom, 0.0f, zRandom);

        if(usedPoints.Contains(tempVector)) 
            tempVector = new Vector3(xRandom, 0.0f, zRandom);
        //     GetRandomPoint();

        return tempVector;
    }
}
