using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject[] Ammos = new GameObject[3];
 
    public void Choose(int index)
    {
        Debug.Log(index);
        for (int i = 0; i < Ammos.Length; i++)
        {
          
            if (i == index)
            {
                Ammos[i].SetActive(true);
            } else
            {
                Ammos[i].SetActive(false);
            }
        }
    }
}
