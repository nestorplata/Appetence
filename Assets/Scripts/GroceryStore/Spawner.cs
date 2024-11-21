using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] gs_pfb;
    public GameObject Spawn_position;
    public boxScript _box;
    private bool nextFruit;
    public static Spawner Instance;
    public Trash_change trash;
    private int moldChecker = 0;

    void Start()
    {
        Instance = this;
    }

    public void change_fruit()
    {
        int temp;
        // try to reduce the amount of moldy food that comes through
        if(moldChecker == 0) {
            temp = Random.Range(0, gs_pfb.Length);
            moldChecker = 1;
        } else {
            // might change to 8 max, cant find reliable info if its inclusive or exclusive
            temp = Random.Range(0, 9);
            moldChecker = 0;
        }
        GameObject gameObject = Instantiate(gs_pfb[temp]);
        gameObject.transform.position = Spawn_position.gameObject.transform.position;
    }

    void Update()
    {
        if (_box.isOpen)
        {
            change_fruit();
            _box.isOpen = false;
        }
    }
}
