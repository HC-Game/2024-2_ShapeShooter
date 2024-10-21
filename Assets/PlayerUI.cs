using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class PlayerUI : MonoBehaviour
{
    public GameObject[] Ammos = new GameObject[3];
    // Start is called before the first frame update
  

    public void Choose(int index)
    {
        for (int i = 0; i < Ammos.Length; i++)
        {
            Debug.Log(index);
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
