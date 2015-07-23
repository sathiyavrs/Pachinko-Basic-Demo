using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeathEffect;
    public GameObject WinEffect;
    public float SpawnAboveValue = 10f;
    public static LevelScript Instance;
    public int MaxNumberOfLives = 3;

    public float NumberOfLives
    {
        get
        {
            return _currentNumberOfLives;
        }
    }

    private GameObject _player;
    private List<ShrinkStars> _stars;
    private int _currentNumberOfLives;
    private bool _hasWon = false;

    public void Start()
    {
        InstantiatePlayer();
        _stars = new List<ShrinkStars>();
        _stars = FindObjectsOfType<ShrinkStars>().ToList<ShrinkStars>();
        Instance = this;
        _currentNumberOfLives = MaxNumberOfLives;

        if (Player == null)
        {
            Debug.LogError("Assign Player to LevelScript!");
            Application.Quit();
        }
    }

    public void Update()
    {
        HandleInput();
    }

    public void KillPlayer()
    {
        DestroyPlayer();
        _currentNumberOfLives--;
        if (_currentNumberOfLives == 0)
            StartCoroutine(RestartGame());
        else
            InstantiatePlayer();
    }

    public void Win()
    {
        _hasWon = true;
        DestroyPlayer();
        StartCoroutine(RestartGame());
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyPlayer();
            _currentNumberOfLives = 0;
            StartCoroutine(RestartGame());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            KillPlayer();
        }
    }

    private void DestroyPlayer()
    {
        if (_player == null)
            return;

        if (!_hasWon)
            if (DeathEffect != null)
                Instantiate(DeathEffect, _player.transform.position, transform.rotation);

        if (_hasWon)
            if (WinEffect != null)
                Instantiate(WinEffect, _player.transform.position, transform.rotation);

        Destroy(_player);
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.5f);
        _currentNumberOfLives = MaxNumberOfLives;
        RespawnStars();
        if (_player != null)
            DestroyPlayer();
        InstantiatePlayer();
        _hasWon = false;
        yield break;
    }

    private void InstantiatePlayer()
    {
        var spawnPosition = transform.position + new Vector3(0, SpawnAboveValue);
        _player = (GameObject)Instantiate(Player, spawnPosition, transform.rotation);
    }

    private void RespawnStars()
    {
        foreach (ShrinkStars star in _stars)
        {
            star.Respawn();
        }
    }
}
