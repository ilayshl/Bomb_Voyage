using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerSupply : MonoBehaviour
{
    [SerializeField] private Sprite connectedWire;
    [SerializeField] private Sprite brokenPowerSupply;
    [SerializeField] private Image connectedWireObject;
    [SerializeField] private Image disconnectedWireObject;
    private Image supplyImage;
    private bool isConnected=false;
    private bool isActive=false;

    // Start is called before the first frame update
    private void Awake()
    {
        supplyImage = GetComponent<Image>();
        connectedWireObject.enabled = false;
        disconnectedWireObject.enabled = true;
    }

    public void SetConnected()
    {
        connectedWireObject.enabled = true;
        disconnectedWireObject.enabled = false;
        isConnected=true;
    }

    public void SetActiveSupply()
    {

        isActive=true;
    }

    public void OnPowerBreak()
    {
        supplyImage.sprite = brokenPowerSupply;
        HammerThePower parent = GetComponentInParent<HammerThePower>();
        parent.OnPowerBreak(isConnected, isActive);
        GetComponent<Button>().enabled = false;
    }
}
