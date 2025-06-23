using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Tree")]
public class TreeSO : ScriptableObject
{
    public List<Row> Rows;

    public void LoadComponent()
    {
        for (int i = 0; i < Rows.Count; i++)
        {
            Rows[i].LoadComponent(i + 1);
        }
    }
}
