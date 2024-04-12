using System.Collections;
using System.Collections.Generic;
using UnityEditor.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

public class CardFlipManager : MonoBehaviour
{
    private GameObject raycastObj;
    private bool isCardFlipStart;
    // Start is called before the first frame update
    void Start()
    {
        isCardFlipStart = true;
    }
    private void CastRay()
    {
        raycastObj = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null)
        {
            raycastObj = hit.collider.gameObject;
            Debug.Log(raycastObj.name);
        }
    }
    // 만들어야 하는것
    // - 카드 프리팹 생성 => 카드 2*n개 생성, 각 카드별 설정
    // - 카드 짝 맞추기 => 성공하면 그대로 실패하면 다시 뒤집기
    // - 카드 뒤집는 애니메이션
    // - 게임 종료 조건
    // - 타이머
    //
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)&&isCardFlipStart)
        {
            CastRay();
        }
    }
}
