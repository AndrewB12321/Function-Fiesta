using System.Collections.Generic;
using UnityEngine;

public class LogEQ : Function
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void updateGraph()
    {
        linePoints = new Vector3[numPoints];
        colPoints = new Vector2[numPoints];
        int lowerVal = x1 < x2 ? x1 : x2;
        int higherval = x1 > x2 ? x1 : x2;
        List<float> xValues = new List<float>();

        for (int i = lowerVal; i < higherval; i++)
        {

            float current_xValue = i;
            for (int j = 0; j < pointsPerUnit; j++)
            {
                xValues.Add(current_xValue);
                current_xValue += 1.0f / pointsPerUnit;
            }
        }

        for (int i = 0; i < numPoints; i++)
        {
            float xVal = xValues[i];
            float yVal = Mathf.Log(xVal + a, b) + c;
            linePoints[i] = new Vector3(xVal, yVal, 0);
            colPoints[i] = new Vector2(xVal, yVal);
        }
    }
}
