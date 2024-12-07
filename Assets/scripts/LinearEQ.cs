using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LinearEQ : Function

{
    public InputField a_val;
    public InputField b_val;
    public InputField c_val;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        numPoints = 2;
        initializeGraph();
        a_val = GetComponent<InputField>();
        b_val = GetComponent<InputField>();
    }

    // Update is called once per frame
    public override void Update()
    {
        updateGraph();
        drawGraph(linePoints, colPoints);
    }


    
    public override void updateGraph()
    {
        float y1 = this.x1 * a + b;
        float y2 = this.x2 * a + b;
        Vector3 point1 = new Vector3(x1, y1, -1);
        Vector3 point2 = new Vector3(x2, y2, -1);
        Vector3[] linePoints = { point1, point2 };
        Vector2[] colPoints = { point1, point2 };
        this.linePoints = linePoints;
        this.colPoints = colPoints;
        Debug.Log("its me!!! im calling the derived function!!!");

    }
    // all the other graphs need to make sure there are the correct points
    // but a line only needs 2 points so it only has 2 points
    public override void drawGraph()
    {
        lr.SetPositions(linePoints);
        edgeCol.points = colPoints;
    }

    public override void ProccessInput()
    {

        string b_input = b_val.text;
        // accepts integers, decimals with one decimal or integer/integer
        a = stringToFloat(a_val.text);
        b = stringToFloat(b_val.text);


    }

}
