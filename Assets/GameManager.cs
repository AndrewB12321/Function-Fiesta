using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] keys;
    public GameObject[] doors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        doors = GameObject.FindGameObjectsWithTag("Doors");
    }
}
