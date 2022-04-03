using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLevelHandler : MonoBehaviour
{
    private static Image batteryLevel;

    /// <summary>
    /// Sets the battery level value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetBatteryLevelValue(float value)
    {
        batteryLevel.fillAmount = value;
        if(batteryLevel.fillAmount < 0.2f)
        {
            SetBatteryLevelColor(Color.red);
        }
        else if(batteryLevel.fillAmount < 0.4f)
        {
            SetBatteryLevelColor(Color.yellow);
        }
        else
        {
            SetBatteryLevelColor(Color.green);
        }
    }

    public static float GetBatteryLevelValue()
    {
        return batteryLevel.fillAmount;
    }

    /// <summary>
    /// Sets the battery level color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetBatteryLevelColor(Color healthColor)
    {
        batteryLevel.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        batteryLevel = GetComponent<Image>();
    }
}
