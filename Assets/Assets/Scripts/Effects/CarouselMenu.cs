using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class CarouselMenu : MonoBehaviour
{
    //private Vector2 startPos;
    //private Vector2 endPos;
    //public GameObject content;

    //public float swipeThreshold = 50f;

    //public List<GameObject> menu = new List<GameObject>();

    //public int pageIndex = 0;


    public RectTransform content;
    public Button[] btns;
    public RectTransform center;

    private float[] distance;
    private bool dragging = false;
    private int btnDistance;
    private int minBtnNum;

    public void Start()
    {
        int btnLength = btns.Length;
        btnDistance = (int)Mathf.Abs(btns[1].GetComponent<RectTransform>().anchoredPosition.x - btns[0].GetComponent<RectTransform>().anchoredPosition.x);
        distance = new float[btnLength];
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    startPos = Input.mousePosition;
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    endPos = Input.mousePosition;
        //    if (menu == null || pageIndex < menu.Count)
        //    {
        //        pageIndex++;
        //        Debug.Log("Page Index: " + pageIndex);
        //    }
        //    else
        //    {
        //        pageIndex = 0;
        //        Debug.Log("When the If statment resets " + pageIndex);
        //    }

        //    DetectSwipe(pageIndex);
        //}


        for(int i = 0; i < btns.Length; i++)
        {
            distance[i] = Mathf.Abs(center.anchoredPosition.x - btns[i].GetComponent<RectTransform>().anchoredPosition.x);
        }

        minBtnNum = 0;
        float minDistance = Mathf.Min(distance);

        for (int j = 1; j < btns.Length; j++)
        {
            if (distance[j] < minDistance)
            {
                minDistance = distance[j];
                minBtnNum = j;
            }
        }

        if (!dragging)
        {
            LerpToBtn(minBtnNum * -btnDistance);
        }
    }

    void LerpToBtn(int position)
    {
        float newX = Mathf.Lerp(content.anchoredPosition.x, position, Time.deltaTime * 10f);

        if (Mathf.Abs(newX - position) < 0.01f)
        {
            newX = position;
        }

        content.anchoredPosition = new Vector2(newX, content.anchoredPosition.y);
    }
    public void StartDrag()
    {
        dragging = true;
    }

    public void StopDrag() {
        dragging = false;
    }

    //void DetectSwipe(int index)
    //{
    //    float deltaX = endPos.x - startPos.x;


    //    if (Mathf.Abs(deltaX) > swipeThreshold)
    //    {
    //        if (deltaX > 0)
    //        {
    //            menu[index].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, menu[0].GetComponent<RectTransform>().anchoredPosition.y);

    //            Debug.Log("Swipe Right");
    //        }else
    //        {
    //            menu[index].GetComponent<RectTransform>().anchoredPosition = new Vector2(-250, menu[0].GetComponent<RectTransform>().anchoredPosition.y);
    //            Debug.Log("Swipe Left");
    //        }

    //    }
    //}
}