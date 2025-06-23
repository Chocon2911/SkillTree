using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NodeIndex
{
    public int rowIndex;
    public int nodeIndex;

    public NodeIndex(int rowIndex, int nodeIndex)
    {
        this.rowIndex = rowIndex;
        this.nodeIndex = nodeIndex;
    }
}
