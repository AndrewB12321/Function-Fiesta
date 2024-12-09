using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Windows;
using TMPro;

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

    [Header("InputFields")]
    public TMP_InputField a_val;
    public TMP_InputField b_val;
    public TMP_InputField c_val;
    public TMP_InputField x1_val;
    public TMP_InputField x2_val;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        numPoints = Mathf.Abs(x1 - x2) * pointsPerUnit;
        initializeGraph();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        updateEnteredValues();
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

        lr.positionCount = numPoints;
        lr.SetPositions(linePoints);
        edgeCol.points = colPoints;
    }

<<<<<<< HEAD


    public virtual void updateEnteredValues()

    {
        if (x1_val.text.Length != 0 && x1_val.text != "-")
            this.x1 = int.Parse(x1_val.text);

        if (x2_val.text.Length != 0 && x2_val.text != "-")
            this.x2 = int.Parse(x2_val.text);
            
        if (a_val.text.Length != 0 && a_val.text != "-")
            this.a = float.Parse(a_val.text);

        if (b_val.text.Length != 0 && b_val.text != "-")
            this.b = float.Parse(b_val.text);

        if(c_val != null && c_val.text.Length != 0 && c_val.text != "-")
            this.c = float.Parse(c_val.text);
    }
}
