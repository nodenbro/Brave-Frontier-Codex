using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickArea : MonoBehaviour
{
    public float alphaThreshold = 0.5f;
    void OnGUI()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }
}
