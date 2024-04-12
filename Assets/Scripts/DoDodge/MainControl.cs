using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainControl: MonoBehaviour //전체 두더지게임 관리
{
    private float currentTime = 0f;

    public static MainControl Inst; //temporary singleton
    public TMP_Text TMP_Time;
    public int womanSeat = -1; //여자가 아직 안 앉은 상태
    public delegate void stopGame();
    public static event stopGame StopGame;

    private IEnumerator StartTimer()
    {
        while (currentTime < 60f) //제한시간 60초
        {
            TMP_Time.text = ((int)currentTime).ToString(); //경과 시간 표시

            currentTime += Time.deltaTime;
            yield return null;
        }
        Fail(); //60초 초과 시 실패
    }

    public void Penalty(float time)
    {
        currentTime += time;
    }

    public void Clear(int manSeat)
    {
        StopAllCoroutines(); //타이머 정지
        StopGame(); //이벤트 델리게이트로 모든 버튼 비활성화
        TMP_Time.text = (Mathf.Abs(womanSeat - manSeat) == 1) ?
            "Clear, 호감도 +5" : "Clear, 호감도 X"; //여자와 남자가 붙어 있을 시 호감도 +5
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
