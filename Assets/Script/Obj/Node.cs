using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    public int rowIndex;
    public int currLevel;
    public NodeSO so;

    public bool LevelUp(List<Row> rows)
    {
        if (this.rowIndex != 1 && !rows[rowIndex - 2].CanChildNodeLevelUp(rows)) return false;
        if (this.currLevel == so.MaxLevel) return false;
        this.currLevel++;
        return true;
    }
}
