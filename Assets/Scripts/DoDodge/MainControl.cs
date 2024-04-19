using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainControl: MonoBehaviour //��ü �δ������� ����
{
    private float _currentTime = 0f;

    public static MainControl Inst; //temporary singleton
    public TMP_Text TMP_Time;
    public int womanSeat = -1; //���ڰ� ���� �� ���� ����
    public delegate void stopGame();
    public static event stopGame StopGame;

    private IEnumerator StartTimer()
    {
        while (_currentTime < 60f) //���ѽð� 60��
        {
            TMP_Time.text = ((int)_currentTime).ToString(); //��� �ð� ǥ��

            _currentTime += Time.deltaTime;
            yield return null;
        }
        Fail(); //60�� �ʰ� �� ����
    }

    private bool IsNextSeat(int seat1, int seat2)
    {
        if (Mathf.Abs(seat1 - seat2) == 1) return true;
        return false;
    }

    public void Clear(int manSeat)
    {
        StopAllCoroutines(); //Ÿ�̸� ����
        StopGame(); //�̺�Ʈ ��������Ʈ�� ��� ��ư ��Ȱ��ȭ
        TMP_Time.text = IsNextSeat(womanSeat, manSeat) ?
            "Clear, ȣ���� +5" : "Clear, ȣ���� X"; //���ڿ� ���ڰ� �پ� ���� �� ȣ���� +5
    }

    public void Fail()
    {
        StopGame();
        TMP_Time.text = "Fail";
    }

    public void Penalty(float time)
    {
        _currentTime += time;
    }


    void Start()
    {
        if (Inst == null) Inst = this;
        else Destroy(this); //temporary singleton

        StartCoroutine(StartTimer());
    }

}
