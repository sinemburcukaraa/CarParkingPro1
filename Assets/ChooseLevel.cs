using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    public static ChooseLevel instance;
    public List<GameObject> ButtonList = new List<GameObject>();
    public int index;
    public GameObject SelectedLevel›ndex;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            ButtonList.Add(this.transform.GetChild(i).gameObject);
        }
    }
}
