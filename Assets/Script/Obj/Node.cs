using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class Node
{
    public int rowIndex;
    public int currLevel;
    public NodeSO so;
    public List<InterfaceReference<Requirement>> requirement;

    public bool LevelUp(List<Row> rows)
    {
        if (this.currLevel == so.MaxLevel) return false;
        if (this.rowIndex == 0)
        {
            this.currLevel++;
            return true;
        }

        if (!rows[rowIndex].CanLevelUp(rows)) return false;
        foreach (InterfaceReference<Requirement> requirement in this.requirement)
        {
            if (!requirement.Value.IsGood(rows)) return false;
        }

        this.currLevel++;
        return true;
    }
}
