using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header(" Sonidos ")]
    [SerializeField] private AudioSource buttonSounds;
    [SerializeField] private AudioSource letterAddedSounds;
    [SerializeField] private AudioSource letterRemovedSounds;
    [SerializeField] private AudioSource levelCompleteSounds;
    [SerializeField] private AudioSource gameOverSounds;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        InputManager.onLetterAdded += PlayLetterAddedSound;
        InputManager.onLetterRemoved += PlayLetterRemovedSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onLetterAdded -= PlayLetterAddedSound;
        InputManager.onLetterRemoved -= PlayLetterRemovedSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.NivelCompleto:
                levelCompleteSounds.Play();
                break;

            case GameState.GameOver:
                gameOverSounds.Play();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSound()
    {
        buttonSounds.Play();
    }

    private void PlayLetterAddedSound()
    {
        letterAddedSounds.Play();
    }

    private void PlayLetterRemovedSound()
    {
        letterRemovedSounds.Play();
    }

    public void EnableSound()
    {
        buttonSounds.volume = 1;
        letterAddedSounds.volume = 1;
        letterRemovedSounds.volume = 1;
        levelCompleteSounds.volume = 1;
        gameOverSounds.volume = 1;
            
    }
    public void DisableSound()
    {
        buttonSounds.volume = 0;
        letterAddedSounds.volume = 0;
        letterRemovedSounds.volume = 0;
        levelCompleteSounds.volume = 0;
        gameOverSounds.volume = 0;
    }


}
