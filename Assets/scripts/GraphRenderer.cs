using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public GameObject linePrefab;



    public enum functionType
    {
        linear,
        quadratic,
        exponential,
        log
    }

    bool gameOver;



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
                Debug.Log("This function was called!");
                break;
            case functionType.quadratic:
                GameObject newQuad = Instantiate(linePrefab);
                newQuad.AddComponent<QuadraticEQ>();
                break;
            case functionType.exponential:
                GameObject newExp = Instantiate(linePrefab);
                newExp.AddComponent<ExponentialEQ>();
                break;
            case functionType.log:
                GameObject newLog = Instantiate(linePrefab);
                newLog.AddComponent<LogEQ>();
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

}
