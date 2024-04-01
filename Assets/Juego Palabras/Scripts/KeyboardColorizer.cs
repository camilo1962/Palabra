using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorizer : MonoBehaviour
{
    [Header(" Elementos ")]
    private KeyboardKey[] keys;

    [Header(" Ajustes ")]
    private bool shouldReset;

    private void Awake()
    {
        keys = GetComponentsInChildren<KeyboardKey>();
    }

    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
                if(shouldReset)
                    Initialize();

                break;

            case GameState.NivelCompleto:
                shouldReset = true;
                break;

            case GameState.GameOver:
                shouldReset = true;

                break;
        }
    }

    private void Initialize()
    {
        for(int i = 0; i < keys.Length; i++)
            keys[i].Initialize();


        shouldReset = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Colorize(string secretWord, string wordToCheck)
    {
        for(int i =0; i < keys.Length; i++)
        {
            char keyLetter = keys[i].GetLetter();

            for (int j = 0; j < wordToCheck.Length; j++)
            {
                if (keyLetter != wordToCheck[j])
                    continue;

                //la letra clave que hemos presionado es igual a la letra actual de la palabra To chek

                if(keyLetter == secretWord[j])
                {
                    //valida
                    keys[i].SetValid();
                }
                else if (secretWord.Contains(keyLetter))
                {
                    //potencial
                    keys[j].SetPotential();
                }
                else
                {
                    //Invalida
                    keys[i].SetInvalid();
                }
            }
        }
    }


}
