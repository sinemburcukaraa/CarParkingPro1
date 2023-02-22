using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Start()
    {
        CarController.instance.DirectionArrow.SetActive(true);
    }
    private void Awake()
    {
        if (!instance)
            instance = this;

       
    }
}
