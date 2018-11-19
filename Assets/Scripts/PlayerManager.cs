using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private const int MAX_PLAYERS = 4;

    public List<GameObject> Players;

    void OnValidate()
    {
        Players.RemoveAll(player => !player);
        if (Players.Count > MAX_PLAYERS)
        {
            Debug.LogWarning(string.Format("Cannot have more than {0} players!", MAX_PLAYERS));
            //Players.RemoveRange(MAX_PLAYERS, Players.Count - MAX_PLAYERS);
        }
    }

    // Use this for initialization
    void Start()
    {
        int sqrtCeil = (int)Math.Ceiling(Math.Sqrt(Players.Count));
        int horizontalCells = sqrtCeil;
        int verticalCells = (int)Math.Ceiling((float)Players.Count / sqrtCeil);
        float width = 1.0f / horizontalCells;
        float height = 1.0f / verticalCells;
        for (int y = 0; y < verticalCells; y++)
        {
            for (int x = 0; x < horizontalCells && (y * sqrtCeil + x) < Players.Count; x++)
            {
                Players[y * sqrtCeil + x].SendMessage("SetViewportRect", new Rect(x * width, 1.0f - (y * height) - height, width, height));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
