using UnityEngine;

// PropertyAttribute - базовый класс для создания пользовательских аттрибутов 
[System.Serializable]
public class ColorRangeAttributeBase : PropertyAttribute
{
	public Color Min;
	public Color Max;

	public ColorRangeAttributeBase(float r1, float g1, float b1, float a1,
							   float r2, float g2, float b2, float a2)
	{
		this.Min = new Color(r1, g1, b1, a1);
		this.Max = new Color(r2, g2, b2, a2);
	}

}

// этот аттрибут модифицируем в Editor
[System.Serializable]
public class ColorRangeAttribute : PropertyAttribute
{
	public Color Min;
	public Color Max;

	public ColorRangeAttribute(float r1, float g1, float b1, float a1,
	                           float r2, float g2, float b2, float a2)
	{
		this.Min = new Color(r1, g1, b1, a1);
		this.Max = new Color(r2, g2, b2, a2);
	}

}


[System.Serializable]
public class ColorBlend : System.Object
{
	public Color SourceColor = Color.white;
	public Color DestColor = Color.white;
	public Color BlendedColor = Color.white;
	public float BlendFactor = 0f;
}


public class ColorAdjuster : MonoBehaviour
{
	[ColorRangeAttributeBase(1f, 0f, 0f, 0f, 0f, 1f, 0f, 1f)]
	public ColorBlend MyColorBlendBase;

	[Space(50)]

	[ColorRangeAttribute(1f,0f,0f,0f,   0f,1f,0f,1f)]
	public ColorBlend MyColorBlend;
}