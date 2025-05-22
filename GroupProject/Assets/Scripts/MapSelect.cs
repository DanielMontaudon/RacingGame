using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapSelect : MonoBehaviour
{
    public void DesertMap()
    {
        SceneManager.LoadScene(2);
    }

    public void CityMap()
    {
        SceneManager.LoadScene(3);
    }

    public void SpaceMap()
    {
        SceneManager.LoadScene(4);
    }
}
