using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    [SerializeField] private int _totalFood;
    [SerializeField] private int _totalGrill;
    [SerializeField] private Transform _gridGrill;

    private List<GrillStation> _listGrills;
    private float _avgTray;
    private List<Sprite> _totalSpriteFood;

    private void Awake()
    {
        _listGrills = Utils.GetListInChild<GrillStation>(_gridGrill);
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Items");
        _totalSpriteFood = loadedSprites.ToList();
    }

    private void Start()
    {
        OnInitLevel();
    }

    private void OnInitLevel()
    {
        List<Sprite> takeFood = _totalSpriteFood.OrderBy(x => Random.value).Take(_totalFood).ToList();
        List<Sprite> useFood = new List<Sprite>();
            
        for (int i = 0; i < takeFood.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                useFood.Add(takeFood[i]);
            }
        }

        for (int i = 0; i < useFood.Count; i++)
        {
            int rand = Random.Range(0, useFood.Count);
            (useFood[i], useFood[rand]) = (useFood[rand], useFood[i]);
        }

        _avgTray = Random.Range(1.5f, 2.5f);
        int totalTray = Mathf.RoundToInt(useFood.Count / _avgTray);

        List<int> trayPerGrill = DistributeEvelyn(_totalGrill, totalTray);
        List<int> foodPerGrill = DistributeEvelyn(_totalGrill, useFood.Count);

        for (int i = 0; i < _listGrills.Count; i++)
        {
            bool activeGrill = i < _totalGrill;
            _listGrills[i].gameObject.SetActive(activeGrill);

            if (activeGrill)
            {
                List<Sprite> lisFood = Utils.TakeAndRemoveRandom(useFood, foodPerGrill[i]);
                _listGrills[i].OnInitGrill(trayPerGrill[i], lisFood);
            }
        }
    }

    private List<int> DistributeEvelyn(int grillCount, int totalTrays)
    {
        List<int> result = new List<int>();

        float avg = totalTrays / grillCount;
        int low = Mathf.FloorToInt(avg);
        int high = Mathf.CeilToInt(avg);

        int highCount = totalTrays - low * grillCount;
        int lowCount = grillCount - highCount;

        for (int i = 0; i < lowCount; i++)
        {
            result.Add(low);
        }
        
        for (int i = 0; i < highCount; i++)
        {
            result.Add(high);
        }

        for (int i = 0; i < result.Count; i++)
        {
            int rand = Random.Range(0, result.Count);
            (result[i], result[rand]) = (result[rand], result[i]);
        }

        return result;
    }
}
