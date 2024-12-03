using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Graph2D : MonoBehaviour
{
    public LineRenderer lr;
    public EdgeCollider2D edgeCol;

    [Header("Graph Equation")]
    public float xSquaredTerm = 1f; // Coefficient for x^2
    public float xTerm = 0f;       // Coefficient for x
    public float constant = 0f;   // Constant term

    [Header("Graph Settings")]
    public int numPoints = 100;    // Number of points on the graph
    public float xRange = 10f;     // Range for x (-xRange to xRange)
    public Vector2 scale = Vector2.one; // Scale for the graph (x and y)

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
        float step = (xRange * 2) / (numPoints - 1); // Step size for x
        float xVal = -xRange;

        Vector2[] colliderPoints = new Vector2[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            // Calculate the y value for the given x value
            float yVal = (xSquaredTerm * Mathf.Pow(xVal, 2)) + (xTerm * xVal) + constant;

            // Apply scaling
            points[i] = new Vector3(xVal * scale.x, yVal * scale.y, 0);
            colliderPoints[i] = new Vector2(xVal * scale.x, yVal * scale.y);

            // Increment x value by step
            xVal += step;
        }

        // Update LineRenderer
        lr.SetPositions(points);

        // Update EdgeCollider2D
        edgeCol.points = colliderPoints;
    }
}
