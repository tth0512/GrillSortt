using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static List<T> GetListInChild<T>(Transform parent)
    {
        List<T> result = new List<T>();

        for (int i = 0; i < parent.childCount; i++)
        {
            var component = parent.GetChild(i).GetComponent<T>();
            if (component != null)
            {
                result.Add(component);
            }
        }

        return result;
    }

    public static List<T> TakeAndRemoveRandom<T>(List<T> source, int n)
    {
        List<T> result = new List<T>();
        n = Mathf.Min(n, source.Count);

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, source.Count);
            result.Add(source[index]);
            source.RemoveAt(index);
        }

        return result;
    }
}
