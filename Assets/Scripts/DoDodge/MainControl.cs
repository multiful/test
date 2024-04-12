using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainControl: MonoBehaviour //��ü �δ������� ����
{
    private float currentTime = 0f;

    public static MainControl Inst; //temporary singleton
    public TMP_Text TMP_Time;
    public int womanSeat = -1; //���ڰ� ���� �� ���� ����
    public delegate void stopGame();
    public static event stopGame StopGame;

    private IEnumerator StartTimer()
    {
        while (currentTime < 60f) //���ѽð� 60��
        {
            TMP_Time.text = ((int)currentTime).ToString(); //��� �ð� ǥ��

            currentTime += Time.deltaTime;
            yield return null;
        }
        Fail(); //60�� �ʰ� �� ����
    }

    public void Penalty(float time)
    {
        currentTime += time;
    }

    public void Clear(int manSeat)
    {
        StopAllCoroutines(); //Ÿ�̸� ����
        StopGame(); //�̺�Ʈ ��������Ʈ�� ��� ��ư ��Ȱ��ȭ
        TMP_Time.text = (Mathf.Abs(womanSeat - manSeat) == 1) ?
            "Clear, ȣ���� +5" : "Clear, ȣ���� X"; //���ڿ� ���ڰ� �پ� ���� �� ȣ���� +5
    }

    public void Fail()
    {
        StopGame();
        TMP_Time.text = "Fail";
    }


    void Start()
    {
        if (Inst == null) Inst = this;
        else Destroy(this); //temporary singleton

        StartCoroutine(StartTimer());
    }

}
