using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameters
{
    public static GameParameters Instance = new();

    public string? Category;

    private GameParameters()
    {

    }
}
