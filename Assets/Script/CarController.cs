using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    public GameObject DirectionArrow;
    public Image image;
    public Canvas ParkingImageCanvas;
    public int Price;
    public bool LockControlBool;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "struckobject")
        {
            GameManager.instance.GameOver();
        }
    }
}
