using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class Function : MonoBehaviour 
{

    public int x1 = -5; // default values, will be changed by ui
    public int x2 = 5;
    public int scale = 2; // 2 unity units per 1 graph unit
    public float a = 1.0f;   
    public float b = 2f;   // a,b,c are the scalars for each function, not every base class will use them all 
    public float c = 1.0f;   
    public int pointsPerUnit = 4; 
    public LineRenderer lr;
    public EdgeCollider2D edgeCol;
    public int numPoints;
    public Vector3[] linePoints;
    public Vector2[] colPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        numPoints = Mathf.Abs(x1 - x2) * pointsPerUnit;
        initializeGraph();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        numPoints = Mathf.Abs(x1 - x2) * pointsPerUnit;
        updateGraph();
        drawGraph();

    }
    // function to update the points, overridden in base classes
   public virtual void updateGraph() {
        Debug.Log("im calling the empty base function :((((");
   }

    public void initializeGraph()
    {
        if (!lr)
        {
            lr = GetComponent<LineRenderer>();
        }
        if (!edgeCol)
        {
            edgeCol = GetComponent<EdgeCollider2D>();
        }

        lr.positionCount = numPoints;
        lr.widthMultiplier = 0.1f;
    }
    public virtual void drawGraph()
    {
        if (linePoints.Length != numPoints)
            throw new ArgumentException("Length of linePoints != numPoints: linePoints = " + linePoints.Length + ", numPoints = " + numPoints);
        if (colPoints.Length != numPoints)
            throw new ArgumentException("Length of colPoints != numPoints: colPoints = " + colPoints.Length + ", numPoints = " + numPoints);

        lr.SetPositions(linePoints);
        edgeCol.points = colPoints;
    }

    public void updateEnteredValues(int x1, int x2, int a, int b, int c)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public virtual void ProccessInput()
    {

    }

    public float stringToFloat(string text)
    {
        string reg = @"^\d+(\.\d+)?(\/\d+)?$";
        if (Regex.IsMatch(text, reg))
        {
            return float.Parse(text);
        }
        else
        {
            Debug.Log("invalid input");
            return 0;
        }
    }
}

    
