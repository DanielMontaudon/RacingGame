using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject[] carList;
    public int carChoice = 0;

    //public bool gamePlaying;

    void Awake()
    {
        //gamePlaying = false;
        carList[carChoice].SetActive(true);
    }
    
}
