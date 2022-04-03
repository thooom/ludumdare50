using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectLogic : MonoBehaviour
{
    private List<GameObject> objectsToPlace;
    public GameObject lastPlacedObject;
    public static bool HasActiveFan = false;
    public static bool HasActivePlank = false;

    void Awake()
    {
        objectsToPlace = new List<GameObject>();
        objectsToPlace.Add(Resources.Load<GameObject>("Prefabs/Fan"));
        objectsToPlace.Add(Resources.Load<GameObject>("Prefabs/Plank"));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ButtonPushed.SelectedButton != -1)
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
            DestroyObject();
        }
    }

    private void PlaceObject()
    {
        if (ButtonPushed.SelectedButton > -1 && ButtonPushed.SelectedButton < objectsToPlace.Count)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            lastPlacedObject = Instantiate(objectsToPlace[ButtonPushed.SelectedButton], position, Quaternion.identity);

            if (ButtonPushed.SelectedButton == 0)
            {
                ButtonPushed.HasActiveFan = true;
            }
            else if (ButtonPushed.SelectedButton == 1)
            {
                ButtonPushed.HasActivePlank = true;
            }
        
            ButtonPushed.SelectedButton = -1;
        }
    }

    private void RotateObject()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastPlacedObject.transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        lastPlacedObject.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }

    private void DestroyObject()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);

        if (hit.collider != null && hit.collider.gameObject.tag == "Deletable")
        {
            if (hit.collider.gameObject.name.Contains("Fan"))
            {
                ButtonPushed.HasActiveFan = false;
            }
            else if (hit.collider.gameObject.name.Contains("Plank"))
            {
                ButtonPushed.HasActivePlank = false;
            }

            Destroy(hit.collider.gameObject);
        }
    }
}
