//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2019 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RCC_Vehicles : MonoBehaviour {

	public RCC_CarControllerV3[] vehicles;
	#region singleton
	public static RCC_Vehicles Instance;
    public int selectedIndex = 0;           // Selected vehicle index. Next and previous buttons are affecting this value.
    public bool gameStartedBool = false;
   
    public GameObject CarSelectionCanvas;
    public TextMeshProUGUI TotalMoneyText;
    public int totalMoney;

    public bool NextSceneBool = false;

    private void Awake()
    {
        totalMoney=PlayerPrefs.GetInt("TotalMoney");//yerini ayarla sonrasında    
        TotalMoneyText.text = totalMoney.ToString();
        if(!Instance)
        {
            Instance = this;
        }
    }
    //public static RCC_Vehicles Instance{	get{if(instance == null) instance = Resources.Load("RCC Assets/RCC_Vehicles") as RCC_Vehicles; return instance;}}
    #endregion

 
}
