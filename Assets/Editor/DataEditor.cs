using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class DataEditor : OdinMenuEditorWindow
{
    [MenuItem("My Windows/ScriptableObjects")]
    private static void OpenWindow()
    {
        GetWindow<DataEditor>().Show();
    }

    private CreateNewEnemyData createNewEnemyData;
    private CreateNewTowerData createNewTowerData;

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (createNewEnemyData != null)
        {
            DestroyImmediate(createNewEnemyData.enemies);
        }
        if (createNewTowerData != null)
        {
            DestroyImmediate(createNewTowerData.towers);
        }
    }
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        createNewEnemyData = new CreateNewEnemyData();
        tree.Add("Enemies/Create New Enemy", createNewEnemyData);
        tree.AddAllAssetsAtPath("Enemies", "Assets/ScriptableObject/Enemies", typeof(Enemies),true);

        createNewTowerData = new CreateNewTowerData();
        tree.Add("Towers/Create New Tower", createNewTowerData);
        tree.AddAllAssetsAtPath("Towers", "Assets/ScriptableObject/Towers", typeof(Towers),true,true);

        return tree;
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection selected = this.MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();
            if (SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                Enemies asset = selected.SelectedValue as Enemies;
                string path = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }
    public class CreateNewEnemyData
    {
        public CreateNewEnemyData()
        {
            enemies = ScriptableObject.CreateInstance<Enemies>();
            enemies.EnemyName = "New Enemy Data";
        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public Enemies enemies;

        [Button("Add New Enemy Scriptable Object")]
        private void createNewData()
        {
            AssetDatabase.CreateAsset(enemies, "Assets/ScriptableObject/Enemies/" + enemies.EnemyName + ".asset");
            AssetDatabase.SaveAssets();

            enemies = ScriptableObject.CreateInstance<Enemies>();
            enemies.EnemyName = "New Enemy Data";
        }
    }

    public class CreateNewTowerData
    {
        public CreateNewTowerData()
        {
            towers = ScriptableObject.CreateInstance<Towers>();
            towers.towerName = "New Tower Data";
        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public Towers towers;

        [Button("Add New Enemy Scriptable Object")]
        private void createNewData()
        {
            AssetDatabase.CreateAsset(towers, "Assets/ScriptableObject/Towers/" + towers.towerName + ".asset");
            AssetDatabase.SaveAssets();

            towers = ScriptableObject.CreateInstance<Towers>();
            towers.towerName = "New Tower Data";
        }
    }
}
