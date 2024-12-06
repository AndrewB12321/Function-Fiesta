using JetBrains.Annotations;
using UnityEngine;

public class LinearEQ : Function

{

    public float slope;
    public float b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Vector3[] createPoints()
    {
        float y1 = this.x1 * slope + b;
        float y2 = this.x2 * slope + b;
        Vector3 point1 = new Vector3(x1, y1, -1);
        Vector3 point2 = new Vector3(x2, y2, -1);
        Vector3[] points = {point1, point2};
        return points;
    }
}
