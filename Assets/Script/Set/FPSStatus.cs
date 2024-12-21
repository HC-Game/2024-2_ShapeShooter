using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSStatus : MonoBehaviour
{
    public TextMeshProUGUI a;
    // Update is called once per frame
    
    void Update()
    {
        a.text = $"{1 / Time.deltaTime}";
    }
}
