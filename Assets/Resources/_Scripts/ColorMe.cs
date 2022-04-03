using UnityEngine;

public class ColorMe : MonoBehaviour
{
    SpriteRenderer[] children;
    MaterialManager materialManager;

    private void Start()
    {
        materialManager = GetComponent<MaterialManager>();
        children = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer c in children)
        {
            c.material = materialManager.GiveMeColor();
        }
    }
}
