using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e) 
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // Clean up old keys
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }
        // Instantiate current key list
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            keyTemplate.gameObject.SetActive(true);
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(false);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 25);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.White: keyImage.color = Color.white;   break;
                case Key.KeyType.Red:   keyImage.color = Color.red;     break;
                case Key.KeyType.Green: keyImage.color = Color.green;   break;
                case Key.KeyType.Blue:  keyImage.color = Color.blue;    break;
            }
        }
    }
}
