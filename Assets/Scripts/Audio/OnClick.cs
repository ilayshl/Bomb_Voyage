using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour
{
    private GameManager _gameManager;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = _gameManager.GetComponentInChildren<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _audioManager.PlaySound("Click");
    }

    public void PlayClick()
    {
        _audioManager.PlaySound("Click");
    }

}
    