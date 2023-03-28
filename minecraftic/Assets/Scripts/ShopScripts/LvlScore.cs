using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlScore : MonoBehaviour
{
    [SerializeField] private Text textScore;

    private void Update()
    {
        textScore.text = GameManager.lvls.ToString();
    }
}
