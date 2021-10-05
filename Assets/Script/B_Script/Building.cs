using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class Building : ScriptableObject
{
    new public string name = "New Building";
    public int id;
    public GameObject BuildingPrefab;
}
