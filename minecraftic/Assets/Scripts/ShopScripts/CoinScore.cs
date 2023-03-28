using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private Text textScore;

    private void Update()
    {
        textScore.text = GameManager.coins.ToString();
    }
}
