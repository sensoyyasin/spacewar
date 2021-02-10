﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{
    public GameObject oyun_bitti_pnl;
    

    public void paneli_goster()
    {
        oyun_bitti_pnl.SetActive(true);

        Invoke("durdur", 1.0f);
    }

    void  durdur()
    {
        Time.timeScale = 0.0f;
    }

    public void tekrar_oyna()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/oyun");
    }

    
    
}
