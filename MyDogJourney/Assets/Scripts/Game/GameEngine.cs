using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public MainGame Game { get; private set; }
    

    void Start()
    {
        Game = new MainGame();
        Game.Start();
    }

    private void Update()
    {
        Game.Update();
    }
}
