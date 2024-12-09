using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LinearEQ : Function
{
    public TMP_InputField a_val;
    public TMP_InputField b_val;
    public TMP_InputField c_val;
    public TMP_InputField x1_val;
    public TMP_InputField x2_val;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        initializeGraph();
        a_val = GetComponent<TMP_InputField>();
        b_val = GetComponent<TMP_InputField>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        updateGraph();
        base.Update();
    }

    public override void updateGraph()
    {
        linePoints = new Vector3[numPoints];
        colPoints = new Vector2[numPoints];
        int lowerVal = x1 < x2 ? x1 : x2;
        int higherVal = x1 > x2 ? x1 : x2;
        List<float> xValues = new List<float>();

        for (int i = lowerVal; i < higherVal; i++)
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
            float yVal = xVal * a + b;
            linePoints[i] = new Vector3(xVal, yVal, 0);
            colPoints[i] = new Vector2(xVal, yVal);
        }
    }

    public override void ProccessInput()
    {
        string b_input = b_val.text;
        // accepts integers, decimals with one decimal or integer/integer
        a = stringToFloat(a_val.text);
        b = stringToFloat(b_val.text);
    }
}
