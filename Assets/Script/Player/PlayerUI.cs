using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public GameObject[] AmmosUI = new GameObject[3];
    public GameObject[] HealthUI = new GameObject[3];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Choose(int index)
    {
  
        for (int i = 0; i < AmmosUI.Length; i++)
        {
          
            if (i == index)
            {
                AmmosUI[i].SetActive(true);
            } else
            {
                AmmosUI[i].SetActive(false);
            }
        }
    }
    #region HP
    public void HPSet(int index)
    {
        for(int i = 0; i<HealthUI.Length;i++)
            if(i<index)
            HealthUI[i].SetActive(true);
            else if(i>=index)
            HealthUI[i].SetActive(false);
    }

    public int GetMaxHealth() {
        return HealthUI.Length;
    }
    #endregion
}
