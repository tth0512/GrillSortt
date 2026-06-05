using UnityEngine;
using UnityEngine.UI;

public class FoodSlot : MonoBehaviour
{
    private Image _imgFood;

    private void Awake()
    {
        _imgFood = transform.GetChild(0).GetComponent<Image>();
        _imgFood.gameObject.SetActive(false);
    }

    public void OnSetSlot(Sprite spr)
    {
        _imgFood.gameObject.SetActive(true);
        _imgFood.sprite = spr;
        _imgFood.SetNativeSize();
    }

    public bool HasFood()
    {
        return _imgFood.gameObject.activeInHierarchy;
    }
}
