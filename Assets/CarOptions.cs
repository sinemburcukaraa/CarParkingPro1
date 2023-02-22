using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CarOptions : MonoBehaviour
{
    float maxsimumEngineTork;
    float maxsimumBrakeTorque;
    float MaxSpeed;
    public static CarOptions instance;
    public List<Slider> sliderList = new List<Slider>();
    public int PriceCar;
    public TextMeshProUGUI moneyText;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //for (int i = 0; i < this.transform.childCount; i++)
        //{
        //    sliderList.Add(this.transform.GetChild(i).gameObject.GetComponent<Slider>());
        //}
        SliderOptions();
    }
    public void SliderOptions()
    {
        maxsimumEngineTork = ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].gameObject.GetComponent<RCC_CarControllerV3>().engineTorque;
        sliderList[0].value = maxsimumEngineTork / 600;//0.1
        maxsimumBrakeTorque = ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].gameObject.GetComponent<RCC_CarControllerV3>().brakeTorque;
        sliderList[1].value = maxsimumEngineTork / 500;
        MaxSpeed = ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].gameObject.GetComponent<RCC_CarControllerV3>().maxspeed;
        sliderList[2].value = maxsimumEngineTork / 500;

        PriceCar = ChooseCar.instance.carArray[RCC_Vehicles.Instance.selectedIndex].GetComponent<CarController>().Price;
        moneyText.text = PriceCar.ToString();
        LocControl.instance.lockOptions();

    }
}
