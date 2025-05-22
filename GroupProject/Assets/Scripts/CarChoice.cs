using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoice : MonoBehaviour
{
    public GameObject BRZ;
    public GameObject InitalD;
    public GameObject WRX;

    public int carImport;

    // Start is called before the first frame update
    void Start()
    {
        carImport = CarSelect.carType;
        if(carImport == 1)
        {
            BRZ.SetActive(true);
        }

        if(carImport == 2)
        {
            InitalD.SetActive(true);
        }

        if(carImport == 3)
        {
            WRX.SetActive(true);
        }
    }

   
}
