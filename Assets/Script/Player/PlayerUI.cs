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
            DontDestroyOnLoad(gameObject); // 씬 전환 시 GameManager를 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Choose(int index)
    {
        Debug.Log(index);
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
    public void HPMinus1(int index)
    {
        HealthUI[index].SetActive(false);
    }
    public void HPPlus1(int index)
    {
        HealthUI[index].SetActive(true);
    }
    public int GetMaxHealth() {
        return HealthUI.Length;
    }
    #endregion
}
