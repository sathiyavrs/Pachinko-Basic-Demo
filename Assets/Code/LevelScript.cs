using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelScript : MonoBehaviour
{
    public GameObject Player;
    public float SpawnAboveValue = 10f;

    private GameObject _player;
    private List<ShrinkStars> _stars;

    public void Start()
    {
        InstantiatePlayer();
        _stars = new List<ShrinkStars>();
        _stars = FindObjectsOfType<ShrinkStars>().ToList<ShrinkStars>();
    }

    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(_player);
            InstantiatePlayer();
            RespawnStars();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void InstantiatePlayer()
    {
        var spawnPosition = transform.position + new Vector3(0, SpawnAboveValue);
        _player = (GameObject)Instantiate(Player, spawnPosition, transform.rotation);
    }

    private void RespawnStars()
    {
        foreach(ShrinkStars star in _stars)
        {
            star.Respawn();
        }
    }
}
