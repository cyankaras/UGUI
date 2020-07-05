using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScroll : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect scrollRect;
    private float[] pageArray = new float[] { 0, 0.33f, 0.66f, 1.1f };
    private float targetHorizontalpostion=0;
    public float speed = 5;
    private bool isDraging = false;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraging == false)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizontalpostion, Time.deltaTime * speed);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        //取得拖拽结尾的坐标
        Vector2 temp = scrollRect.normalizedPosition;
        float temp2 = scrollRect.horizontalNormalizedPosition;
        print(temp2);

        //EndDrag的点
        float posX = scrollRect.horizontalNormalizedPosition;
        //预设的页码
        int index = 0;
        //差值运算
        float offset = Mathf.Abs(pageArray[index] - posX);
        for (int i = 0; i < pageArray.Length; i++)
        {
            float offsetTemp = Mathf.Abs(pageArray[i] - posX);
            if (offsetTemp < offset)
            {
                index = i;
                //实现跳页
                offset = offsetTemp;
            }
        }
        //scrollRect.horizontalNormalizedPosition = pageArray[index];
        targetHorizontalpostion = pageArray[index];
    }
}
