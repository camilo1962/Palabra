using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header(" Datos ")]
    private int coins;
    private int score;
    private int record;

    [Header(" Eventos ")]
    public static Action onCoinsUpdated;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveData();

        onCoinsUpdated?.Invoke();

    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        coins = Mathf.Max(coins, 0);
        SaveData();

        onCoinsUpdated?.Invoke();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (score > record)
            record = score;

        SaveData();
    }

    public void ResetScore()
    {
        score = 0;
        SaveData();
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetScore()
    {
        return score;
    }
    

    public int GetBestScore()
    {
        return record;
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("coins", 150);
        score = PlayerPrefs.GetInt("score");
        record = PlayerPrefs.GetInt("record");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("record", record);
    }
}
