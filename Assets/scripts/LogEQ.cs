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
        Debug.Log(c);
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

    public override void updateEnteredValues()
    {
        if (x1_val.text.Length != 0 && x1_val.text != "-")
            this.x1 = int.Parse(x1_val.text);

        if (x2_val.text.Length != 0 && x2_val.text != "-")
            this.x2 = int.Parse(x2_val.text);

        if (this.x1 < 0)
        {
            this.x1 = 0;
            x1_val.text = "0";
        } 

        if (this.x2 < 0)
        {
            this.x2 = 0;
            x2_val.text = "0";
        }

        if (a_val.text.Length != 0 && a_val.text != "-")
            this.a = float.Parse(a_val.text);

        if (b_val.text.Length != 0 && b_val.text != "-")
            this.b = float.Parse(b_val.text);

        Debug.Log("C_val is: " + c_val + ". C_val.text is: " + c_val.text);

        if (c_val.text.Length != 0 && c_val.text != "-")
            Debug.Log("is this getting called?");
            this.c = float.Parse(c_val.text);
    }
}
