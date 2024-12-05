using UnityEngine;

public class EquationUIManager : MonoBehaviour
{
    public GameObject linearPrefab;
    public GameObject exponentialPrefab;
    public GameObject logarithmicPrefab;
    public GameObject quadraticPrefab;

    public Transform equationDisplayContainer;

    private const int MaxEquations = 4; // Maximum number of equations allowed

    public void ShowLinearEquation()
    {
        AddEquation(linearPrefab);
    }

    public void ShowExponentialEquation()
    {
        AddEquation(exponentialPrefab);
    }

    public void ShowLogarithmicEquation()
    {
        AddEquation(logarithmicPrefab);
    }

    public void ShowQuadraticEquation()
    {
        AddEquation(quadraticPrefab);
    }

    private void AddEquation(GameObject prefab)
    {
        if (equationDisplayContainer.childCount >= MaxEquations)
        {
            Destroy(equationDisplayContainer.GetChild(0).gameObject);
        }

        Instantiate(prefab, equationDisplayContainer);
    }

    public void ClearDisplay()
    {
        foreach (Transform child in equationDisplayContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void Start()
    {
        ClearDisplay();
    }
}
