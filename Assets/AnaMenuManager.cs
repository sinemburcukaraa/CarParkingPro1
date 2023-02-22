using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuManager : MonoBehaviour
{
    public GameObject GameMenu;
    public GameObject LevelsMenu;
    public GameObject RCCCanvasCarSelection;
    public GameObject StartPanel;
    public GameObject InsufficientMoney;
    public void OpenGarage()
    {
        RCCCanvasCarSelection.SetActive(true);
        StartPanel.SetActive(false);
    }
    public void chooseGameMenu()
    {
        StartPanel.SetActive(false);
        GameMenu.SetActive(true);
    }
    
    public void InsufficientMoneyPanelBack()
    {
        InsufficientMoney.SetActive(false);
    }
    public void BackButton()
    {
        print("backbutton");
        StartPanel.SetActive(true);
        GameMenu.SetActive(false);
    }
    public void BackButton2()
    {
        RCCCanvasCarSelection.SetActive(false);
        StartPanel.SetActive(true);

    }
    public void selectButton()
    {
        if (ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].GetComponent<CarController>().LockControlBool)
        {
            RCCCanvasCarSelection.SetActive(false);
            StartPanel.SetActive(true);

        }
    }
    public void levelsMenu()
    {
        LevelsMenu.SetActive(true);
        GameMenu.SetActive(false);

    }
    public void GameScene()
    {
        LevelsMenu.SetActive(false);
    }
    public void playButton() 
    {
        LevelManager.instance.NextLevel();
    }
    public void playerPrefControl()
    {
        PlayerPrefs.SetInt("LevelCount", ChooseLevel.instance.index);
        PlayerPrefs.SetInt("nextLevel", ChooseLevel.instance.index);
    }
}
