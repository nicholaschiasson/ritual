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
        List<GameObject> players = new List<GameObject>(Players);
        players.Reverse();
        int sqrtCeil = (int)Math.Ceiling(Math.Sqrt(Players.Count));
        int verticalCells = (int)Math.Ceiling((float)players.Count / sqrtCeil);
        float height = 1.0f / verticalCells;
        for (int y = 0; y < verticalCells; y++)
        {
            int horizontalCells = Math.Min(sqrtCeil, players.Count - y * sqrtCeil);
            float width = 1.0f / horizontalCells;
            for (int x = 0; x < horizontalCells && (y * sqrtCeil + x) < players.Count; x++)
            {
                players[y * sqrtCeil + x].SendMessage("SetViewportRect", new Rect(1.0f - (x * width) - width, y * height, width, height));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
