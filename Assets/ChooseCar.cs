using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    public static ChooseCar instance;
    public GameObject[] carArray;
    //public List<GameObject> carArray = new List<GameObject>();
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}
