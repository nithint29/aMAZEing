using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    public GameObject WallPrefab;
    public GameObject FloorPrefab;

    public float Scale = 1f;

	void Awake()
	{
        Debug.Log("GameManager initialized.");

        LoadMazeFromFile("Assets/maze.txt");
	}

	// Use this for initialization
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMazeFromFile(string filepath) {
        StreamReader reader = new StreamReader(filepath);

        GameObject floor = Instantiate(FloorPrefab,
                                       Vector3.zero,
                                       Quaternion.identity)
            as GameObject;
        floor.transform.localScale = new Vector3(100, 1, 100);
        floor.transform.parent = GameObject.Find("Walls").transform;

        int row = 0;
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            Debug.Log("Row " + row + ": " + line);
            for (int col = 0; col < line.Length; col++)
            {
                char ch = line[col];
                if (ch == '1')
                {
                    // createPrefab(WallPrefab, row, col);
                    GameObject go = Instantiate(WallPrefab,
                                                new Vector3(col * Scale - 50, 0.5f, -row * Scale + 50),
                                                Quaternion.identity)
                        as GameObject;

                    go.transform.parent = GameObject.Find("Walls").transform;

                    // resize board based on size of matrix?

                }
            }

            row++;
        }
    }

}
