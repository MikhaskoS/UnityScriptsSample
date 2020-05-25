using System;
using UnityEngine;

// Custom serializable class
[Serializable]
public class IngredientUIE
{
    public string name;
    public int amount = 1;
    public IngredientUnit unit;
}

public class RecipeUIE : MonoBehaviour
{
    public IngredientUIE potionResult;
    public IngredientUIE[] potionIngredients;
}
