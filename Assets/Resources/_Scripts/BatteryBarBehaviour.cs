using UnityEngine;
using UnityEngine.UI;

// Source: https://www.youtube.com/watch?v=v1UGTTeQzbo

public class BatteryBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;

    public void SetBatteryBarLevel(float level, float maxLevel) 
    {
        slider.value = level;
        slider.maxValue = maxLevel;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        // slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }
}
