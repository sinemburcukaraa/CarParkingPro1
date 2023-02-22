using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ParkingControl : MonoBehaviour
{
    public bool isFull;
    public int touchCount;
    public GameObject greenParkArea;
    public GameObject TransparentParkArea;
    bool FillAmountControl;
    Canvas FillAmountCanvas;
    Image image2;
    GameObject DirectionArrow;

    private void Start()
    {
        FillAmountCanvas = CarController.instance.ParkingImageCanvas;
        image2 = CarController.instance.image;
        DirectionArrow = CarController.instance.DirectionArrow;
        DirectionArrow.GetComponent<DirectionArrow>().target = this.transform;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wheel")
        {
            touchCount++;
            if (touchCount == 4)
            {
                isFull = true;
                DirectionArrow.gameObject.SetActive(false);
                IsParkedCorrectly();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "wheel")
        {
            if (touchCount == 4)
            {
                AfterTheParked();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wheel")
        {
            isFull = false;
            touchCount--;
            IsParkedCorrectly();
        }
    }

    public void IsParkedCorrectly() //dogru park edilince( sari ve yesil park alanlarýnýn kontrolu)
    {
        if (isFull)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            TransparentParkArea.GetComponent<MeshRenderer>().enabled = false;
            greenParkArea.gameObject.SetActive(true);
            FillAmountControl = true;

        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            TransparentParkArea.GetComponent<MeshRenderer>().enabled = true;
            greenParkArea.gameObject.SetActive(false);
            FillAmountControl = false;

        }
    }
    bool Control;
    public void AfterTheParked() //araba park edildikten sonra ,,Fillamount control
    {
        if (RCC_UIDashboardButton.instance.gearDirection == 1 && FillAmountControl && !Control)
        {

            FillAmountCanvas.gameObject.SetActive(true);
            image2.DOFillAmount(1, 2).OnComplete(() =>
            {
                FillAmountCanvas.gameObject.SetActive(false);
                Control = true;
                GameManager.instance.Win();
            });
        }
        else
        {
            image2.DOKill();
            image2.GetComponent<Image>().fillAmount = 0;
            FillAmountCanvas.gameObject.SetActive(false);
        }

    }



}
