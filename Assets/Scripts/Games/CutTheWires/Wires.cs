using UnityEngine;
using UnityEngine.UI;

public class Wires : MonoBehaviour
{
    [SerializeField] Sprite wireCut;
    private AudioManager aManager;
    private CutTheWires parent;
    private Image image;

    void Awake()
    {
        parent = GetComponentInParent<CutTheWires>();
        image = GetComponent<Image>();
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void OnCut(){
        parent.OnWireCut(image.color);
        image.sprite = wireCut;
        GetComponent<Button>().enabled = false;
    }
}
