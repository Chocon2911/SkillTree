using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Row
{
    //==========================================Variable==========================================
    public ThresholdType threshold;
    public List<Node> nodes;

    public void LoadComponent(int index)
    {        
        foreach (Node node in this.nodes)
        {
            node.rowIndex = index;
        }
    }

    //===========================================Method===========================================
    public int GetIndex(List<Row> rows)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            if (rows[i] != this) continue;
            return i;
        }

        return -1;
    }

    public bool CanChildNodeLevelUp(List<Row> rows)
    {
        switch (this.threshold)
        {
            case ThresholdType.NONE:
                return true;
            case ThresholdType.TWO_OVER_THREE:
                return this.IsCondition1Good();
            case ThresholdType.ABOVE_15_POINTS:
                return this.IsCondition2Good();
            default:
                return false;
        }
    }

    //=========================================Condition==========================================
    public bool IsCondition1Good()
    {
        int unlockedSkillAmount = 0;
        int requiredAmount = 2 * this.nodes.Count / 3;
        foreach (Node node in this.nodes)
        {
            if (node.currLevel < 1) continue;
            unlockedSkillAmount++;
        }

        return unlockedSkillAmount >= requiredAmount ? true : false;
    }

    public bool IsCondition2Good()
    {
        int totalUnlockedPoints = 0;
        int requiredPoints = 15;

        foreach (Node node in this.nodes)
        {
            totalUnlockedPoints += node.currLevel;
        }

        return totalUnlockedPoints >= requiredPoints ? true : false;
    }
}
