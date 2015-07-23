using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class GUIManager : MonoBehaviour
{
    private List<Text> _texts;

    public void Start()
    {
        _texts = new List<Text>();
        _texts = GetComponentsInChildren<Text>().ToList<Text>();
        if (_texts == null)
        {
            Debug.LogError("No Text Found!");
            return;
        }
    }

    public void Update()
    {
        _texts[0].text = "Balls Left: " + LevelScript.Instance.NumberOfLives;

        if (_texts.Count == 1)
            return;

        _texts[1].enabled = false;
        if (LevelScript.Instance.NumberOfLives == 0)
        {
            _texts[1].enabled = true;
            _texts[1].text = "Game Over.\nPress R to Restart.";
        }
        if (LevelScript.Instance.HasWon)
        {
            _texts[1].enabled = true;
            _texts[1].text = "You Won!\nPress R to Restart.";
        }
    }
}
