using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Row
{
    //==========================================Variable==========================================
    public List<InterfaceReference<Requirement>> requirements;
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

    public bool CanLevelUp(List<Row> rows)
    {
        foreach (InterfaceReference<Requirement> requirement in this.requirements)
        {
            if (!requirement.Value.IsGood(rows)) return false;
        }

        return true;
    }

    public int GetTotalPoints()
    {
        int totalPoints = 0;
        foreach (Node node in this.nodes)
        {
            totalPoints += node.currLevel;
        }

        return totalPoints;
    }

    public int GetTotalUnlockedSkillAmount()
    {
        int unlockedSkillAmount = 0;
        foreach (Node node in this.nodes)
        {
            if (node.currLevel < 1) continue;
            unlockedSkillAmount++;
        }

        return unlockedSkillAmount;
    }
}
