using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    bool fan, plank;
    int fanPower;

    void Awake()
    {
        fan = true;
        fanPower = 100;
    }
}
