using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int TotalScore { get; set; } = 0;
    public static Dictionary<int , int > Score = new Dictionary<int, int>();
    public static void AddScore(int level, int levelScore)
    {
        Score[level] = levelScore;
        TotalScore = 0;
        foreach(var value in Score.Values)
        {
            TotalScore += value;
        }
    }
}
