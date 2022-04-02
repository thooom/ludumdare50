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
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && hit.collider.gameObject.tag == "Deletable")
            { 
                hit.collider.gameObject.name
                Destroy(hit.collider.gameObject);
            }
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
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastPlacedObject.transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        lastPlacedObject.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }

    private void PutItemBackInInventory()
    {

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
