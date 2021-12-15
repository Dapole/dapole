using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorСhange : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    private SpriteRenderer colorType;

    private enum KeyType {
        White,
        Red,
        Green,
        Blue
    }

    private void Start()
    {
        colorType = this.GetComponent<SpriteRenderer>();
        switch (keyType)
        {
            default:
            case KeyType.White: colorType.color = Color.white;   break;
            case KeyType.Red:   colorType.color = Color.red;     break;
            case KeyType.Green: colorType.color = Color.green;   break;
            case KeyType.Blue:  colorType.color = Color.blue;    break;
        }
    }

}
