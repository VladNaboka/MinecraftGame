using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Data
    public static int coins;
    public static int lvls = 1;
    public static float[] speedBreak = { 1.2f, 1f, 0.85f, 0.7f, 0.55f, 0.4f, 0.25f, 0.1f };
    public static int[] pickaxeSale = { 50, 112, 168, 252, 378, 557, 850, 1275 };
    public static int[] bootsSale = { 50, 112, 168, 252, 378, 557, 850, 1275 };
    public static int speedCount = 0;

    public static int bootsCount = 0;
    public static int pickaxeCount = 0;

    public static int speedPlayer = 10;

    public static int BuyThing(int sale)
    {
        coins -= sale;
        PlayerPrefs.SetInt("score", coins);
        return PlayerPrefs.GetInt("score");
    }
    public static float SpeedController() => speedBreak[speedCount];
    public static float SpeedBreakAdd()
    {
        speedCount += 1;
        return speedBreak[speedCount];
    }
    public static int Boots() => bootsSale[bootsCount];
    public static int BootsLvl() => bootsCount + 1;
    public static int Pickaxe() => pickaxeSale[pickaxeCount];
    public static int PickaxeLvl() => pickaxeCount + 1;
    public static int BootsAdd()
    {
        bootsCount += 1;
        PlayerPrefs.SetInt("bootsSale", bootsCount);
        return bootsSale[PlayerPrefs.GetInt("bootsSale")];
    }
    public static int PickaxeAdd()
    {
        pickaxeCount += 1;
        PlayerPrefs.SetInt("pickaxeSale", pickaxeCount);
        return pickaxeSale[PlayerPrefs.GetInt("pickaxeSale")];
    }
    public static float SaleController() => pickaxeSale[speedCount + 1];
    public static int SpeedPlayer() => speedPlayer += (100 + 15) / 100;
}
