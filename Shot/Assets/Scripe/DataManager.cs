using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int TotalScore { get; set; } = 0;
    public static void AddScore(int levelScore)
    {
        TotalScore += levelScore;
    }
}
