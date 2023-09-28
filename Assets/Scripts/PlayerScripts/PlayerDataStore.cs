using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataStore
{
    private const string MAX_HEALTH_KEY = "MAX_HEALTH_KEY";
    private const string MAX_MANA_KEY = "MAX_MANA_KEY";
    private const string DAMAGE_KEY = "DAMAGE_KEY";
    private const string SPEED_KEY = "SPEED_KEY";


    public static void SaveMaxHealth(int value)
    {
        PlayerPrefs.SetInt(MAX_HEALTH_KEY, value);
    }
    public static void SaveMaxMana(int value)
    {
        PlayerPrefs.SetInt(MAX_MANA_KEY, value);
    }
    public static void SaveDamage(int value)
    {
        PlayerPrefs.SetInt(DAMAGE_KEY, value);
    }
    public static void SaveSpeed(int value)
    {
        PlayerPrefs.SetInt(SPEED_KEY, value);
    }

    public static int LoadMaxHealth(int defaultValue)
    {
        if (PlayerPrefs.HasKey(MAX_HEALTH_KEY))
            return PlayerPrefs.GetInt(MAX_HEALTH_KEY);
        else
            return defaultValue;

    }
    public static int LoadMaxMana(int defaultValue)
    {
        if (PlayerPrefs.HasKey(MAX_MANA_KEY))
            return PlayerPrefs.GetInt(MAX_MANA_KEY);
        else
            return defaultValue;

    }
    public static int LoadDamage(int defaultValue)
    {
        if (PlayerPrefs.HasKey(DAMAGE_KEY))
            return PlayerPrefs.GetInt(DAMAGE_KEY);
        else
            return defaultValue;

    }
    public static int LoadSpeed(int defaultValue)
    {
        if (PlayerPrefs.HasKey(SPEED_KEY))
            return PlayerPrefs.GetInt(SPEED_KEY);
        else
            return defaultValue;

    }
}
