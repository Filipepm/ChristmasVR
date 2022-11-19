using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyCaneUI : MonoBehaviour
{
    private float candyCaneNum = 0;
    [SerializeField]
    private GameObject candycane1, candycane2, candycane3, candycane4, candycane5;
    public void ChangeColor()
    {
        candyCaneNum += 1;
        switch (candyCaneNum)
        {
            case 1:
                candycane1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;

            case 2:
                candycane2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;

            case 3:
                candycane3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;

            case 4:
                candycane4.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;

            case 5:
                candycane5.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
        }
    }
}
