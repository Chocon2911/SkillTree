using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [NonSerialized] private TreeSO treeSO;
    [NonSerialized] private Node node;
    [SerializeField] private NodeIndex nodeIndex;
    [SerializeField] private TextMeshProUGUI nodeName;
    [SerializeField] private Button levelUpBtn;
    [SerializeField] private TextMeshProUGUI levelTxt;

    //==========================================Get Set===========================================
    public Node Node { get => node; set => node = value; }

    //===========================================Unity============================================
    public override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadComponent(ref this.nodeName, transform.Find("NameTxt"), "LoadNodeName()");
        this.LoadComponent(ref this.levelUpBtn, transform.Find("LevelUpBtn"), "LoadLevelUpBtn()");
        this.LoadComponent(ref this.levelTxt, transform.Find("LevelTxt"), "LoadLevelBtn()");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.nodeName.text = this.node.so.NodeName;
        this.levelTxt.text = this.node.currLevel + "/" + this.node.so.MaxLevel;
    }

    private void Start()
    {
        this.levelUpBtn.onClick.AddListener(this.OnLevelUpBtnClick);
    }

    //===========================================Method===========================================
    public void Default(Node node, TreeSO treeSO, NodeIndex nodeIndex)
    {
        this.treeSO = treeSO;
        this.node = node;
        this.nodeIndex = nodeIndex;
    }
    
    private void OnLevelUpBtnClick()
    {
        this.node.LevelUp(this.treeSO.Rows);
        this.levelTxt.text = this.node.currLevel + "/" + this.node.so.MaxLevel;
    }
}
