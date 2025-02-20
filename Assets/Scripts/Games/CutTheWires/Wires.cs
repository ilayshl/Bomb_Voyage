using UnityEngine;
using UnityEngine.UI;

public class Wires : MonoBehaviour
{
    [SerializeField] Sprite wireCut;
    private CutTheWires parent;
    private Image image;

    void Awake()
    {
        parent = GetComponentInParent<CutTheWires>();
        image = GetComponent<Image>();
    }

    /// <summary>
    /// Sets the color of the object's image.
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        image.color = color;
    }

    /// <summary>
    /// Makes sure the wire can be cut only once.
    /// </summary>
    public void OnCut(){
        parent.OnWireCut(image.color);
        image.sprite = wireCut;
        GetComponent<Button>().enabled = false;
    }
}
