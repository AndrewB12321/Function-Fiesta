using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Graph2D : MonoBehaviour
{
    public LineRenderer lr;
    public EdgeCollider2D edgeCol;
    public float xSquaredTerm = 1f; // Coefficient for x^2
    public float xTerm = 0f;       // Coefficient for x
    public float constant = 0f;   // Constant term
    public int numPoints = 100;    // Number of points on the graph
    public float xRange = 10f;     // Range for x (-xRange to xRange)

    private Vector3[] points;

    void Start()
    {
        InitializeGraph();
    }

    void Update()
    {
        UpdateGraph();
    }

    private void InitializeGraph()
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
        points = new Vector3[numPoints];
    }

    private void UpdateGraph()
    {
        float step = (xRange * 2) / (numPoints - 1);
        float xVal = -xRange;

        Vector2[] colliderPoints = new Vector2[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float yVal = (xSquaredTerm * Mathf.Pow(xVal, 2)) + (xTerm * xVal) + constant;
            points[i] = new Vector3(xVal, yVal, 0);
            colliderPoints[i] = new Vector2(xVal, yVal);
            xVal += step;
        }

        lr.SetPositions(points);

        // Update EdgeCollider2D
        edgeCol.points = colliderPoints;
    }
}
