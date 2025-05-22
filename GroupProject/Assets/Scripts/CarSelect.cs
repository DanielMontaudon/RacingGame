using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelect : MonoBehaviour
{
    public static int carType; //1 = BRZ, 2 = Inital D, 3 = WRX
    public GameObject trackSelect;
    public GameObject manCanvas;

    public void BRZ()
    {
        carType = 1;
        trackSelect.SetActive(true);
        manCanvas.SetActive(false);
    }

    public void IntidalD()
    {
        carType = 2;
        trackSelect.SetActive(true);
        manCanvas.SetActive(false);

    }

    public void WRX()
    {
        carType = 3;
        trackSelect.SetActive(true);
        manCanvas.SetActive(false);

    }

}
