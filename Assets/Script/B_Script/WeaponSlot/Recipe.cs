using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    public int Amount;
}

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;
}
