using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUI : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [SerializeField] private TreeSO so;
    [SerializeField] private Transform content;
    private TreeSO runtimeSO;

    //===========================================Unity============================================
    public override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadComponent(ref this.content, transform.Find("Scroll").Find("Content"), "LoadContent");
    }

    protected override void Awake()
    {
        base.Awake();
        this.runtimeSO = this.so;
        this.BuildTreeUI();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        JsonHandler.SaveToJson(this.runtimeSO, this.runtimeSO.name, "Data");
    }

    //===========================================Method===========================================
    private void BuildTreeUI()
    {
        List<Row> rows = this.runtimeSO.Rows;
        int rowIndex = 0;
        foreach (Row row in rows)
        {
            Transform newRowObj = UISpawner.Instance.SpawnByName("Row", Vector2.zero, Quaternion.identity);
            newRowObj.parent = this.content;
            newRowObj.gameObject.SetActive(true);
            int nodeIndex = 0;
            foreach (Node node in row.nodes)
            {
                Transform newNodeObj = UISpawner.Instance.SpawnByName("Node", Vector2.zero, Quaternion.identity);
                NodeUI nodeUI = newNodeObj.GetComponent<NodeUI>();
                nodeUI.Default(node, this.runtimeSO, new NodeIndex(rowIndex, nodeIndex));
                newNodeObj.parent = newRowObj;
                newNodeObj.gameObject.SetActive(true);
                nodeIndex++;
            }

            rowIndex++;
        }
    }
}
