using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBoots : MonoBehaviour
{
    [SerializeField] private Text textSaleBoots;
    [SerializeField] private Text textCount;
    private void Start()
    {
        textCount.text = GameManager.BootsLvl().ToString();
    }
    private void Update()
    {
        textSaleBoots.text = GameManager.Boots().ToString();
    }
    public void BootsAdd()
    {
        if (GameManager.coins >= GameManager.Boots())
        {
            GameManager.coins -= GameManager.Boots();
            GameManager.BootsAdd();
            GameManager.SpeedPlayer();
            textCount.text = GameManager.BootsLvl().ToString();
        }
    }
}
