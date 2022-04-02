using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectLogic : MonoBehaviour
{
    private List<GameObject> objectsToPlace;
    public GameObject lastPlacedObject;

    void Awake()
    {
        objectsToPlace = new List<GameObject>();
        objectsToPlace.Add(Resources.Load<GameObject>("Prefabs/Fan"));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ButtonPushed.SelectedButton == 0)
            {
                PlaceObject();
            }
        }
        if (lastPlacedObject != null && Input.GetMouseButton(0))
        {
            RotateObject();
        }
        if (lastPlacedObject != null && Input.GetMouseButtonUp(0))
        {
            lastPlacedObject = null;
        }
    }

    private void PlaceObject()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        lastPlacedObject = Instantiate(objectsToPlace[GetActiveObject()], position, Quaternion.identity);
        ButtonPushed.SelectedButton = -1;
    }

    private void RotateObject()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        lastPlacedObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private int GetActiveObject()
    {
        return 0;
        // TODO: Connect med Inventory
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
