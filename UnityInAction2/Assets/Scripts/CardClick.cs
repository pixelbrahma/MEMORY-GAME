using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController sceneController;
    private int id;
    public int Id { get { return id; } }

    public void SetCard(int i,Sprite image)
    {
        id = i;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
        if(cardBack.activeSelf && sceneController.canReveal)
        {
            cardBack.SetActive(false);
            sceneController.CardRevealed(this);
        }
    }
    
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
