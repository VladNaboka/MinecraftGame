using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePickaxe : MonoBehaviour
{
    [SerializeField] private Text textSalePickaxe;
    [SerializeField] private Text textCount;
    private void Start()
    {
        textCount.text = GameManager.PickaxeLvl().ToString();
    }
    private void Update()
    {
        textSalePickaxe.text = GameManager.Pickaxe().ToString();
    }
    public void PickaxeAdd()
    {
        if (GameManager.coins >= GameManager.Pickaxe())
        {
            GameManager.coins -= GameManager.Pickaxe();
            GameManager.PickaxeAdd();
            GameManager.SpeedBreakAdd();
            textCount.text = GameManager.PickaxeLvl().ToString();
        }
    }
}
