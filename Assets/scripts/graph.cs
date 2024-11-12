using System;
using System.Collections;
using System.Xml;
using UnityEngine;

public class graph : MonoBehaviour
{

    public LineRenderer lr;
    public MeshCollider meshCol;
    public float xSquaredTerm;
    public float xTerm;
    public float constant;
    private int numPoints = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr.positionCount = numPoints * 10;
        lr.numCornerVertices = 30;
        lr.widthMultiplier = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        float xVal = -5f; 
        var points = new Vector3[numPoints * 10];
        for(int i = -50; i < 50; i++)
        {
            Vector3 point = new Vector3();
            point.x = xVal;
            point.y = (xSquaredTerm * Mathf.Pow(xVal, 2)) + (xVal * xTerm) + constant;
            point.z = -1;
            points[i + 50] = point;
            xVal += 0.1f;
            Console.WriteLine(xVal);
        }
        lr.SetPositions(points);
        Mesh mesh = new Mesh();
        lr.BakeMesh(mesh, true);
        meshCol.sharedMesh = mesh;
   
    }
}
