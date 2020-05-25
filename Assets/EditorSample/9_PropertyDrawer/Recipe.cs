using System;
using UnityEngine;

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

//https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
// Custom serializable class
[Serializable]
public class Ingredient
{
    public string name;
    public int amount = 1;
    public IngredientUnit unit;
}

public class Recipe : MonoBehaviour
{
    public Ingredient potionResult;
    public Ingredient[] potionIngredients;
}
