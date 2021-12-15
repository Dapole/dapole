using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] public List<GameObject> _items;
    
    public Transform dropPoint;
    // public GameObject itemPrefab;

    public void DropOn ()
    {
        //_items = _items(Random.Range(0, _items.Count);
        // Сделать логику на спаун рандомного количества монет (Нужен риджет бади для монет)
        Instantiate(_items[Random.Range(0, _items.Count)], dropPoint.position, dropPoint.rotation);
        //StartCoroutine(WaitAndGo(0.07F));            
    }
}
