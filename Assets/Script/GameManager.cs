using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public enum GameSit { notStarted, Started, Win, GameOver }
    public bool NextButtonPressed;
    public bool nextLevelBool;
    public GameObject car;

    public GameSit gameSit;
    private void Start()
    {
        
        NotStarted();
    }
    private void Awake()
    {
        if (!instance)
            instance = this;

        car = Instantiate(ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].gameObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

    }
    public int gain;
    public void Win()
    {
        if (gameSit == GameSit.Started)
        {
            gameSit = GameSit.Win;
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
            PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel") + 1);
            gain = PlayerPrefs.GetInt("TotalMoney") + 1000;
            PlayerPrefs.SetInt("TotalMoney", gain);

            RCC_Vehicles.Instance.TotalMoneyText.text = RCC_Vehicles.Instance.totalMoney.ToString();

            UIManager.instance.OpenWinPanel();
        }
    }

    public void GameOver()
    {
        if (gameSit == GameSit.Started)
        {
            gameSit = GameSit.GameOver;
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount"));
            PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel"));

            UIManager.instance.OpengameOverPanel();

        }
    }

    public void Started()
    {
        gameSit = GameSit.Started;

        LevelManager.instance.LevelTextControl();//LEVEL MANAGER AÇINCA AÇ
        UIManager.instance.OpengamePanel();
      
    }

    public void NotStarted()
    {
        if (gameSit != GameSit.Started)
        {
            //gameSit = GameSit.notStarted;


            LevelManager.instance.NextLevel();//LEVEL MANAGER AÇINCA AÇ
            Started();

            //if (Input.GetMouseButtonUp(0))
            //{
            //    //Invoke("Win", 2.0f);
            //}

        }
    }
    public void NextLevelCancas()
    {
        nextLevelBool = true;
    }
}
