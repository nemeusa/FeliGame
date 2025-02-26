using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    public static PointsCounter Instance;
    private int _score;
    [SerializeField] TextMeshProUGUI ScoreText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    public void AddPoints(int _points)
    {
        _score += _points;

        ScoreText.text = _score.ToString("0");

        Debug.Log("Tienes " + _score + " puntos");
    }
}
