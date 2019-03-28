using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    private static int player1Score, player2Score, player3Score, player4Score, previousLevel, previousPreviousLevel;
    private static bool player1 = false, player2 = false, player3 = false, player4 = false, hasHadBonus = false;
    private static List<int> levelList;
    private static int levelPointer = 0;
    private static int roundsPlayed = 0;

    // get & set bonus level bool
    public static bool HasHadBonus
    {
        get
        {
            return hasHadBonus;
        }
        set
        {
            hasHadBonus = value;
        }
    }

    // get & set rounds played
    public static int RoundsPlayed
    {
        get
        {
            return roundsPlayed;
        }
        set
        {
            roundsPlayed = value;
        }
    }

    // get & set level pointer
    public static int LevelPointer
    {
        get
        {
            return levelPointer;
        }
        set
        {
            levelPointer = value;
        }
    }

    // get & set levels
    public static List<int> LevelList
    {
        get
        {
            return levelList;
        }
        set
        {
            levelList = value;
        }
    }

    // get & set players joined
    public static bool Player1
    {
        get
        {
            return player1;
        }
        set
        {
            player1 = value;
        }
    }
    public static bool Player2
    {
        get
        {
            return player2;
        }
        set
        {
            player2 = value;
        }
    }
    public static bool Player3
    {
        get
        {
            return player3;
        }
        set
        {
            player3 = value;
        }
    }
    public static bool Player4
    {
        get
        {
            return player4;
        }
        set
        {
            player4 = value;
        }
    }

    // get & set player Score
    public static int Player1Score
    {
        get
        {
            return player1Score;
        }
        set
        {
            player1Score = value;
        }
    }
    public static int Player2Score
    {
        get
        {
            return player2Score;
        }
        set
        {
            player2Score = value;
        }
    }
    public static int Player3Score
    {
        get
        {
            return player3Score;
        }
        set
        {
            player3Score = value;
        }
    }
    public static int Player4Score
    {
        get
        {
            return player4Score;
        }
        set
        {
            player4Score = value;
        }
    }

    // get & set previousLevel
    public static int PreviousLevel
    {
        get
        {
            return previousLevel;
        }
        set
        {
            previousLevel = value;
        }
    }
    public static int PreviousPreviousLevel
    {
        get
        {
            return previousPreviousLevel;
        }
        set
        {
            previousPreviousLevel = value;
        }
    }
}
