using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CutTheWires : MonoBehaviour
{

    [SerializeField] private Color[] wires = new Color[6];

    [SerializeField] private TextMeshProUGUI[] colorsTexts = new TextMeshProUGUI[6]; //Needs to stay

    private List<Color> colors = new List<Color>()
    {Color.grey, Color.blue, Color.red, Color.yellow, Color.magenta, Color.white};

    private int wiresCut = 0;

    private GameManager _gameManager;

    private AudioManager _aManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _aManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        InitiateGame();
    }

    private void InitiateGame()
    {
        ResetColors();
        foreach(Transform wire in gameObject.transform)
        {
            if(wire.CompareTag("Wire")){
                for(int i=0; i<100; i++)
                {
                int randomIndex = Random.Range(0, wires.Length);
                if(wires[randomIndex]==Color.green){
                    Color randomColor = GetRandomColor();
                    wires[randomIndex] = randomColor;
                    wire.GetComponent<UnityEngine.UI.Image>().color = randomColor;
                    break;
                }
                }
            }
        }
        
        int j = 0;
        foreach(Color color in wires)
        {
            SetText(j, color);
            j++;
        }
    }

    private void ResetColors(){
        for(int i=0; i<wires.Length; i++)
        {
            wires[i] = Color.green;
        }
    }

    private void SetText(int index, Color color)
    {
        colorsTexts[index].color = color;
        colorsTexts[index].SetText(TranslateColor(color));
    }

    private Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Count);
        Color selectedColor = colors.ElementAt(randomIndex);
        colors.RemoveAt(randomIndex);
        return selectedColor;
    }

    private string TranslateColor(Color color)
    {
        string name = "Error";
        string hexString = color.ToHexString();
        switch(hexString){
            case "FF0000FF":
            name = "Red";
            break;
            case "0000FFFF":
            name = "Blue";
            break;
            case "FFEB04FF":
            name = "Yellow";
            break;
            case "FF00FFFF":
            name = "Pink";
            break;
            case "7F7F7FFF":
            name = "Gray";
            break;
            case "FFFFFFFF":
            name = "White";
            break;
        }
        return name;
    }

    public void OnWireCut(Color color)
    {
<<<<<<< Updated upstream
        if(wires[wiresCut] == color)
=======
        _aManager.PlayRandomCable();
        if (wires[wiresCut] == color)
>>>>>>> Stashed changes
        {
            wires[wiresCut] = Color.black;
            wiresCut++;
        }
        else{
            _gameManager.OnLose();
        }
        if(wiresCut == wires.Length)
        {
            GetComponent<Animator>().SetTrigger("gameWon");
        }
    }

    public void OnWin()
    {
        _gameManager.OnWin();
    }
}
