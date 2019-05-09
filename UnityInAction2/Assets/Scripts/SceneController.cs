using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private CardClick originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private const int gridRows = 2;
    [SerializeField] private const int gridColumns = 4;
    [SerializeField] private const float offsetX = 5f;
    [SerializeField] private const float offsetY = 5f;
    [SerializeField] private TextMesh scoreLabel;
    private int score = 0;
    private CardClick card1Open;
    private CardClick card2Open;
    public bool canReveal { get { return card2Open == null; } }
    
    public void CardRevealed(CardClick card)
    {
        if(card1Open==null)
        {
            card1Open = card;
        }
        else
        {
            card2Open = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (card1Open.Id == card2Open.Id)
        {
            score++;
            scoreLabel.text = "SCORE : " + score;   
        }
        else
        {
            yield return new WaitForSeconds(1f);
            card1Open.Unreveal();
            card2Open.Unreveal();
        }
        card1Open = null;
        card2Open = null;
    }

    private void Start()
    {
        Vector3 startPosition = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);
        for(int i = 0; i< gridColumns;i++)
        {
            for(int j=0;j<gridRows;j++)
            {
                CardClick card;
                if(i==0 && j==0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as CardClick;
                }
                int index = j * gridColumns + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPosition.x;
                float posY = -(offsetY * j) + startPosition.y;
                card.transform.position = new Vector3(posX, posY, startPosition.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i=0;i<newArray.Length;i++)
        {
            int temp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = temp;
        }
        return newArray;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Memory");
    }
}