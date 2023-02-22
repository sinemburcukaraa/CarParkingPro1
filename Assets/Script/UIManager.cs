using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject winPanel, gameOverPanel, gamePanel,startPanel;
    public GameObject Camera;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void OpenWinPanel()
    {
        Camera.GetComponent<RCC_Camera>().enabled = false;
        Camera.GetComponent<RCC_CameraCarSelection>().enabled = true;
        Camera.GetComponent<RCC_CameraCarSelection>().target = GameManager.instance.car.transform;

        gamePanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(true);

    }
    public void OpengameOverPanel()
    {
        gamePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true); 

    }
    public void OpengamePanel()
    {
        Camera.GetComponent<RCC_CameraCarSelection>().enabled = false;
        winPanel.gameObject.SetActive(false);

        gamePanel.gameObject.SetActive(true);
    }

    //public void OpenStartPanel()
    //{
    //    startPanel.SetActive(false);
    //}

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
