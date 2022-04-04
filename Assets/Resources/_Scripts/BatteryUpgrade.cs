using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUpgrade : MonoBehaviour
{
    public BatteryBarBehaviour batteryBar;
    void Awake() 
    {
        BoxCollider2D boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        boxCollider.size = new Vector2(2.0f, 4.0f);
        boxCollider.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        Debug.Log(collider.gameObject.name + " : " + collider.name + " : " + Time.time);

        if (collider.gameObject.tag == "Player") {
            // batteryBar = GameObject.Find("BatterySlider").GetComponent<BatteryBarBehaviour>();
            GameObject.Find("BatterySlider").GetComponent<Slider>().value = GameObject.Find("BatterySlider").GetComponent<Slider>().maxValue;
            Destroy(gameObject);
        }
    }
}
