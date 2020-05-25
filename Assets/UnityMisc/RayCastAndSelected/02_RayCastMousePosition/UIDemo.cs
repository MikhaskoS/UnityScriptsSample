using UnityEngine;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{
    [SerializeField] private Text _text1 = null;
    [SerializeField] private Text _text2 = null;
    [SerializeField] private Text _text3 = null;
    [SerializeField] private Text _text4 = null;

    public string Text1 { get => _text1.text; set => _text1.text = value; }
    public string Text2 { get => _text2.text; set => _text2.text = value; }
    public string Text3 { get => _text3.text; set => _text3.text = value; }
    public string Text4 { get => _text4.text; set => _text4.text = value; }
}
