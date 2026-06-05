using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrillStation : MonoBehaviour
{
    [SerializeField] private Transform _trayContainer;
    [SerializeField] private Transform _slotContainer;

    private List<TrayItem> _totalTrays;
    private List<FoodSlot> _totalSlots;

    private void Awake()
    {
        _totalTrays = Utils.GetListInChild<TrayItem>(_trayContainer);
        _totalSlots = Utils.GetListInChild<FoodSlot>(_slotContainer);
    }


    public void OnInitGrill(int totalTray, List<Sprite> listFood)
    {
        int foodCount = Random.Range(1, _totalSlots.Count + 1);
        List<Sprite> list = listFood;
        List<Sprite> listSlot = Utils.TakeAndRemoveRandom<Sprite>(list, foodCount);

        for (int i = 0; i < listSlot.Count; i++)
        {
            FoodSlot slot = RandomSlot();
            slot.OnSetSlot(listSlot[i]);
        }
    }

    private FoodSlot RandomSlot()
    {
    rerand: int n = Random.Range(0, _totalSlots.Count);
        if (_totalSlots[n].HasFood()) goto rerand;

        return _totalSlots[n];
    }
}
