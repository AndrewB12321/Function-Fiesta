using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public GameObject linePrefab;
    private List<GameObject> lines = new List<GameObject>();
    bool gameOver;

    [Header("EquationUIManager")]
    public GameObject linearPrefab;
    public GameObject exponentialPrefab;
    public GameObject logarithmicPrefab;
    public GameObject quadraticPrefab;
    public Transform equationDisplayContainer;

    private const int MaxEquations = 4; // Maximum number of equations allowed

    public enum functionType
    {
        linear,
        quadratic,
        exponential,
        log
    }

    private void Start()
    {
        ClearFunctions();
    }

    public void selectFunction(functionType func)
    {
        switch (func)
        {
            case functionType.linear:
                GameObject newLin = Instantiate(linePrefab);
                GameObject newLinUI = AddEquation(linearPrefab);
                newLin.AddComponent<LinearEQ>();

                newLin.GetComponent<LinearEQ>().a_val = newLinUI.GetComponent<UIInputFieldGetter>().a_val;
                newLin.GetComponent<LinearEQ>().b_val = newLinUI.GetComponent<UIInputFieldGetter>().b_val;
                newLin.GetComponent<LinearEQ>().c_val = newLinUI.GetComponent<UIInputFieldGetter>().c_val;
                newLin.GetComponent<LinearEQ>().x1_val = newLinUI.GetComponent<UIInputFieldGetter>().x1_val;
                newLin.GetComponent<LinearEQ>().x2_val = newLinUI.GetComponent<UIInputFieldGetter>().x2_val;

                lines.Add(newLin);
                break;
            case functionType.quadratic:
                GameObject newQuad = Instantiate(linePrefab);
                GameObject newQuadUI = AddEquation(quadraticPrefab);

                newQuad.AddComponent<QuadraticEQ>();
                lines.Add(newQuad);
                break;
            case functionType.exponential:
                GameObject newExp = Instantiate(linePrefab);
                GameObject newExpUI = AddEquation(exponentialPrefab);

                newExp.AddComponent<ExponentialEQ>();
                lines.Add(newExp);
                break;
            case functionType.log:
                GameObject newLog = Instantiate(linePrefab);
                GameObject newLogUI = AddEquation(logarithmicPrefab);
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

    public void ClearFunctions()
    {
        foreach (Transform child in equationDisplayContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
    }

    private GameObject AddEquation(GameObject prefab)
    {
        if (equationDisplayContainer.childCount >= MaxEquations)
        {
            Destroy(equationDisplayContainer.GetChild(0).gameObject);
        }

        GameObject equationUIElement = Instantiate(prefab, equationDisplayContainer);

        return equationUIElement;
    }
}
