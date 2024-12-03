using JetBrains.Annotations;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public int size = 50;
    public int scale = 1;
    public GameObject lineObject;

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

            Instantiate(lineObject, newPosH, Quaternion.identity, gameObject.transform);
            Instantiate(lineObject, newPosV, Quaternion.Euler(0, 0, 90), gameObject.transform);
        }
    }
}
