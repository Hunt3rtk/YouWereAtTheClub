﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        healthBar.SetSize(1f);
    }

    void Update()
    {
        
    }
}
