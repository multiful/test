using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EachSeat : MonoBehaviour
{

    public enum State
    {
        Sit, Fake, Stand, Woman, Man
    }

    private State currentState = State.Sit;
    public TMP_Text TMP_State;

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(RandomFloat(3f, 7f));
        while (true)
        {
            float rand = RandomFloat(0f, 1f);
            if (rand < 0.33f) StartCoroutine(Fake());
            if (rand > 0.66f) StartCoroutine(Stand());

            yield return new WaitForSeconds(RandomFloat(3f, 7f));
        }
    }

    private void DeActivate()
    {
        StopAllCoroutines();
        GetComponent<Button>().interactable = false;
    }

    private void Sit()
    {
        TMP_State.text = "Sit";
        currentState = State.Sit;
    }

    private IEnumerator Fake()
    {
        TMP_State.text = "Fake";
        currentState = State.Fake;
        yield return new WaitForSeconds(1f);
        Sit();
    }

    private IEnumerator Stand()
    {
        TMP_State.text = "Stand";
        currentState = State.Stand;
        yield return new WaitForSeconds(1f);
        Sit();
    }

    private float RandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }

    public void ButtonClick()
    {
        if (currentState == State.Stand)
        {
            StopAllCoroutines();
            if (MainControl.Inst.manTurn == false)
            {
                MainControl.Inst.manTurn = true;
                TMP_State.text = "Woman";
                currentState = State.Woman;
            }
            else
            {
                TMP_State.text = "Man";
                currentState = State.Man;
                MainControl.Inst.Clear();
            }
        }
        else
        {
            MainControl.Inst.Penalty(10f);
        }
    }

    void Start()
    {
        MainControl.StopGame += DeActivate;
        StartCoroutine(Activate());
    }

}
