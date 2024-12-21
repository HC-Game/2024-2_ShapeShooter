using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : EnemyBase
{
    private void OnEnable()
    {
        base.init();
    }
    private void FixedUpdate()
    {
    
        base.MoveToPlayer();
    }
}
