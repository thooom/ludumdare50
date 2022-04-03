using UnityEngine;
using UnityEngine.U2D;

public class ColorMe : MonoBehaviour
{
    SpriteRenderer[] children;
    SpriteShapeRenderer[] siblings;
    MaterialManager materialManager;

    private void Start()
    {
        materialManager = GameObject.Find("PlayerScripts").GetComponent<MaterialManager>();
        children = GetComponentsInChildren<SpriteRenderer>();
        siblings = GetComponentsInChildren<SpriteShapeRenderer>();
        foreach (SpriteRenderer c in children)
        {
            c.material = materialManager.GiveMeColor();
        }
        foreach (SpriteShapeRenderer s in siblings)
        {
            var materials = s.materials;
            materials[1] = materialManager.GiveMeColor();
            materials[0] = materialManager.GiveMeColor();
            s.materials = materials;
        }
    }
}
