using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Custom serializable class
[Serializable]
public class IngredientStandard
{
    public string name;
    public int amount = 1;
    public IngredientUnit unit;
}

public class RecipeStandard : MonoBehaviour
{
    public IngredientStandard potionResult;
    public IngredientStandard[] potionIngredients;
}
