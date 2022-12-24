using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveStone : MonoBehaviour
{
    public GameObject stone;
    public GameObject water;
    public TMP_Text wheelText;

    public static bool isNewGame = false;

    private void Awake()
    {
        if(isNewGame)
        {
            WaterActivator(false);
            stone.SetActive(false);
        }

        if (!isNewGame)
        {
            if (Point.isActiveWater)
            {
                water.SetActive(true);
            }
            if (Point.isActivePlant)
            {
                stone.SetActive(true);
            }
        }
    }

    private void Start()
    {
        isNewGame = false;
    }

    private void OnEnable()
    {
        PlayerInteraction.iceStonePut += WaterActivator;
        PlayerInteraction.forestStonePut += ForestActivator;
        Point.finishTrigger += GameCompleted;

    }
    private void OnDisable()
    {
        PlayerInteraction.iceStonePut -= WaterActivator;
        PlayerInteraction.forestStonePut -= ForestActivator;
        Point.finishTrigger -= GameCompleted;
    }

    void WaterActivator(bool val)
    {
        water.SetActive(val);
    }
    void ForestActivator(bool val)
    {
        stone.SetActive(val);
    }

    void GameCompleted()
    {
        if (Point.finish + Point.finish1 == 2)
        {
            wheelText.text = "Planet Purpolexia Saved";
        }

    }


}
