using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material[] materials;

    private void Awake()
    {
        materials = Resources.LoadAll<Material>("materials");
    }

    public Material GiveMeColor()
    {
        return materials[Random.Range(0, materials.Length)];
    }
}
