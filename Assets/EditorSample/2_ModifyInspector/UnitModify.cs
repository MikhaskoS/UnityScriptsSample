using UnityEngine;


public class UnitModify : MonoBehaviour
{
    public enum AttackType
    {
        Magic = 1,
        Siege = 2,
        Heavy = 4,
        Chaos = 8
    }

    public Sprite icon;
    public string description = "Описание";
    public float minHealth = 0;
    public float maxHealth = 100;
    public bool rangedUnit;
    public int rangeAttack = 100;
    public AttackType type;
    public float damage = 10;
}
