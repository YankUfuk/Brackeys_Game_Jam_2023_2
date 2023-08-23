using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Depth: " + ((player.position.y)).ToString("0");
    }
}
