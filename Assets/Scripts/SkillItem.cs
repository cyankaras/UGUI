using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    //技能冷却时间
    public float coldTime = 2;
    private float timer = 0;//计时器初始值
    private Image imageFilled;
    private bool isStarTimer = false;//计时器是否开始计时
    [SerializeField]
    private KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        imageFilled = transform.Find("imageSkillFilled").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            isStarTimer = true;
        }
        if (isStarTimer)
        {
            timer += Time.deltaTime;
            imageFilled.fillAmount = (coldTime - timer) / coldTime;
        }
        if (timer>=coldTime)
        {
            imageFilled.fillAmount = 0;
            timer = 0;
            isStarTimer = false;
        }
    }
    public void OnClick()
    {
        isStarTimer = true;
    }
}
