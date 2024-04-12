using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainControl: MonoBehaviour
{
    private float currentTime = 0f;

    public static MainControl Inst; //temporary singleton
    public TMP_Text TMP_Time;
    public bool manTurn = false;
    public delegate void stopGame();
    public static event stopGame StopGame;

    private IEnumerator StartTimer()
    {
        while (currentTime < 60f)
        {
            TMP_Time.text = currentTime.ToString();

            currentTime += Time.deltaTime;
            yield return null;
        }
        Fail();
    }

    public void Penalty(float time)
    {
        currentTime += time;
    }

    public void Clear()
    {
        StopAllCoroutines();
        StopGame();
        TMP_Time.text = "Clear";
    }

    public void Fail()
    {
        StopGame();
        TMP_Time.text = "Fail";
    }


    void Start()
    {
        if (Inst == null) Inst = this;
        else Destroy(this);
        StartCoroutine(StartTimer());
    }

}
