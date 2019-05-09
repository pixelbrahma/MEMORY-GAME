using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highLightColor = Color.white;
    private Color originalColor;

    public void OnMouseEnter()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        if (spriteRenderer!=null)
        {
            spriteRenderer.color = highLightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer!=null)
        {
            spriteRenderer.color = originalColor;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale *= 1.1f; ;
    }

    public void OnMouseUp()
    {
        transform.localScale /= 1.1f;
        if(targetObject!=null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
