using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject LevelP;
    public List<GameObject> LevelList = new List<GameObject>();
    public TextMeshProUGUI LevelCountText;
    public int nextLevelCount;
    private void Awake()
    {
        if (!instance)
            instance = this;

    }
    private void Start()
    {

        for (int i = 0; i < LevelP.transform.childCount; i++)
        {
            LevelP.transform.GetChild(i).gameObject.SetActive(false);
            LevelList.Add(LevelP.transform.GetChild(i).gameObject);
        }
    }

    public void LevelTextControl()
    {
        int levelTextCount = PlayerPrefs.GetInt("LevelCount") + 1;
        LevelCountText.text = "LEVEL " + levelTextCount;
    }
    public void NextLevel()
    {
        if (LevelP.transform.childCount <= PlayerPrefs.GetInt("nextLevel"))
        {
            PlayerPrefs.SetInt("nextLevel", 0);
            nextLevelCount = PlayerPrefs.GetInt("nextLevel");
        }
        else
        {
            nextLevelCount = PlayerPrefs.GetInt("nextLevel");

        }
        nextLevelSystemControl();

        LevelP.transform.GetChild(nextLevelCount).gameObject.SetActive(true);
        GameManager.instance.Started();

    }

    public void nextLevelSystemControl()
    {

        if (nextLevelCount > 0)
        {
            LevelP.transform.GetChild(nextLevelCount - 1).gameObject.SetActive(false);

        }
        if (nextLevelCount == 0)
        {
            LevelP.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

}
