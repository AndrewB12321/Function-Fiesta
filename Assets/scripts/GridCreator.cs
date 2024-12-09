using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public int size = 50;
    public int scale = 1;
    public GameObject lineObject;
    public GameObject numberObject;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = size * -1; i < size; i += scale)
        {
            Vector3 newPosH = new(i, 0, 1);
            Vector3 newPosV = new(0, i, 1);

            numberObject.GetComponent<TextMeshPro>().text = (i / scale).ToString();

            Instantiate(numberObject, newPosH, Quaternion.identity, gameObject.transform);
            Instantiate(numberObject, newPosV, Quaternion.identity, gameObject.transform);

            if(i == 0)
            {
                lineObject.GetComponent<Transform>().localScale = new(0.12f, 100, 0);
                
                Instantiate(lineObject, newPosH, Quaternion.identity, gameObject.transform);
                Instantiate(lineObject, newPosV, Quaternion.Euler(0, 0, 90), gameObject.transform);

                lineObject.GetComponent<Transform>().localScale = new(0.02f, 100, 0);
            } 
            else
            {
                Instantiate(lineObject, newPosH, Quaternion.identity, gameObject.transform);
                Instantiate(lineObject, newPosV, Quaternion.Euler(0, 0, 90), gameObject.transform);
            }
        }
    }
}
