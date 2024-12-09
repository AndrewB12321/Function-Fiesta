using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public GameObject linePrefab;
    private List<GameObject> lines = new List<GameObject>();
    bool gameOver;


    public enum functionType
    {
        linear,
        quadratic,
        exponential,
        log
    }




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void selectFunction(functionType func)
    {
        switch (func)
        {
            case functionType.linear:
                GameObject newLin = Instantiate(linePrefab);
                newLin.AddComponent<LinearEQ>();
                lines.Add(newLin);
                break;
            case functionType.quadratic:
                GameObject newQuad = Instantiate(linePrefab);
                newQuad.AddComponent<QuadraticEQ>();
                lines.Add(newQuad);
                break;
            case functionType.exponential:
                GameObject newExp = Instantiate(linePrefab);
                newExp.AddComponent<ExponentialEQ>();
                lines.Add(newExp);
                break;
            case functionType.log:
                GameObject newLog = Instantiate(linePrefab);
                newLog.AddComponent<LogEQ>();
                lines.Add(newLog);
                break;
        }
    }

    public void addLinear()
    {
        selectFunction(functionType.linear);
    }

    public void addQuadratic()
    {
        selectFunction(functionType.quadratic);
    }

    public void addExponential()
    {
        selectFunction(functionType.exponential);
    }

    public void addLog()
    {
        selectFunction(functionType.log);
    }

    public void clearFunctions()
    {
        foreach (var line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
    }

}
