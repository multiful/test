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
    // ������ �ϴ°�
    // - ī�� ������ ���� => ī�� 2*n�� ����, �� ī�庰 ����
    // - ī�� ¦ ���߱� => �����ϸ� �״�� �����ϸ� �ٽ� ������
    // - ī�� ������ �ִϸ��̼�
    // - ���� ���� ����
    // - Ÿ�̸�
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
