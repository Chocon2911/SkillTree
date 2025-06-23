using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private TreeSO treeSO_1;
    [SerializeField] private TreeSO treeSO_2;

    private void Start()
    {
        this.MyTest1();
        JsonSaver.SaveToJson(this.treeSO_1, "treeSO_1", "Data");
        Debug.Log("==================End Part 1===============");
        this.MyTest2();
        JsonSaver.SaveToJson(this.treeSO_2, "treeSO_2", "Data");
        Debug.Log("==================End Part 2===============");
    }

    private void MyTest1()
    {
        Debug.Log("Row2 - Node3", gameObject);
        this.LevelUpNode(this.treeSO_1.Rows[1].nodes[2]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row3 - Node1", gameObject);
        this.LevelUpNode(this.treeSO_1.Rows[2].nodes[0]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row1 - Node1", gameObject);
        this.LevelUpNode(this.treeSO_1.Rows[0].nodes[0]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row1 - Node2", gameObject);
        this.LevelUpNode(this.treeSO_1.Rows[0].nodes[1]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node3", gameObject);
        this.LevelUpNode(this.treeSO_1.Rows[1].nodes[2]);
        Debug.Log("==============================", gameObject);
    }

    private void MyTest2()
    {
        Debug.Log("Row1 - Node1", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[0].nodes[0]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row1 - Node2", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[0].nodes[1]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row3 - Node1", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[2].nodes[0]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node3", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[2]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node3", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[2]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node3", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[2]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node4", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[3]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node4", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[3]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node4", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[3]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node5", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[4]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node5", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[4]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node5", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[4]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node6", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[5]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node6", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[5]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node6", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[5]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row2 - Node7", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[1].nodes[6]);
        Debug.Log("==============================", gameObject);

        Debug.Log("Row3 - Node0", gameObject);
        this.LevelUpNode2(this.treeSO_2.Rows[2].nodes[0]);
        Debug.Log("==============================", gameObject);
    }

    private void LevelUpNode(Node node)
    {
        if (node.LevelUp(this.treeSO_1.Rows))
        {
            Debug.Log(node.so.name + ": Level up to lvl_" + node.currLevel, gameObject);
        }
        else
        {
            Debug.Log(node.so.name + ": Can't level up, current lvl_" + node.currLevel, gameObject);
        }
    }

    private void LevelUpNode2(Node node)
    {
        if (node.LevelUp(this.treeSO_2.Rows))
        {
            Debug.Log(node.so.name + ": Level up to lvl_" + node.currLevel, gameObject);
        }
        else
        {
            Debug.Log(node.so.name + ": Can't level up, current lvl_" + node.currLevel, gameObject);
        }
    }
}
