using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocControl : MonoBehaviour
{
    public List<GameObject> lockAndImage = new List<GameObject>();
    public static LocControl instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        for (int i = 0; i < this.transform.childCount; i++)
        {
            lockAndImage.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public void lockOptions()
    {
        if (ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].GetComponent<CarController>().LockControlBool)
        {
            lockAndImage[0].SetActive(true);
            lockAndImage[1].SetActive(false);
        }
        else
        {
            lockAndImage[0].SetActive(false);
            lockAndImage[1].SetActive(true);

        }
    }
    int prefsMoney;
    public void BuyCar() 
    {
        if (RCC_Vehicles.Instance.totalMoney>= CarOptions.instance.PriceCar)
        {
            ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].GetComponent<CarController>().LockControlBool = true;

            RCC_Vehicles.Instance.totalMoney -= CarOptions.instance.PriceCar;
            PlayerPrefs.SetInt("TotalMoney", RCC_Vehicles.Instance.totalMoney);
            RCC_Vehicles.Instance.TotalMoneyText.text = RCC_Vehicles.Instance.totalMoney.ToString();

            lockOptions();
        }
    }
}
