using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayItem : MonoBehaviour
{
    private List<Image> _foodList;

    private void Awake()
    {
        _foodList = Utils.GetListInChild<Image>(transform);
    }

    public void OnSetFood(List<Sprite> items)
    {
        if (items.Count <= _foodList.Count)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Image slot = RandomSlot();
                slot.gameObject.SetActive(true);
                slot.sprite = items[i];
                slot.SetNativeSize(); 
            }
        }
    }

    private Image RandomSlot() 
    {
    rerand: int n = Random.Range(0, _foodList.Count);
        if (_foodList[n].gameObject.activeInHierarchy) goto rerand;

        return _foodList[n]; 
    }
}
