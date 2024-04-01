using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState { Menu, Game, NivelCompleto, GameOver, Inactivo}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header(" Ajustes ")]
    private GameState gameState;

    [Header(" Eventos ")]
    public static Action<GameState> onGameStateChanged;
    internal string secretWord;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void NextButtonCallback()
    {
        SetGameState(GameState.Game);
    }

    public void PlayButtonCallback()
    {
        SetGameState(GameState.Game);
    }

    public void BackButtonCallback()
    {
        SetGameState(GameState.Menu);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
