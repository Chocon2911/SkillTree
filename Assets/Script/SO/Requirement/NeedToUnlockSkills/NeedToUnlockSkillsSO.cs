using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Requirement/NeedToUnlockSkills")]
public class NeedToUnlockSkillsSO : ScriptableObject, Requirement
{
    [Serializable]
    public class NodeIndex
    {
        public int rowIndex;
        public int nodeIndex;
    }

    public List<NodeIndex> nodeIndices = new List<NodeIndex>();

    bool Requirement.IsGood(List<Row> rows)
    {
        foreach (NodeIndex nodeIndex in nodeIndices)
        {
            Debug.Log(rows[nodeIndex.rowIndex].nodes[nodeIndex.nodeIndex].currLevel);
            Debug.Log(rows[nodeIndex.rowIndex].nodes[nodeIndex.nodeIndex].so.name);
            if (rows[nodeIndex.rowIndex].nodes[nodeIndex.nodeIndex].currLevel <= 0) return false;
        }
        return true;
    }
}
