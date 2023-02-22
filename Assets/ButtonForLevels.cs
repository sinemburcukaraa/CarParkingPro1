using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForLevels : MonoBehaviour
{
    public void Button›ndex()
    {
        ChooseLevel.instance.index = ChooseLevel.instance.ButtonList.IndexOf(this.gameObject)-1;
        print(ChooseLevel.instance.index);

        RCC_Vehicles.Instance.NextSceneBool = true;
    }
}
