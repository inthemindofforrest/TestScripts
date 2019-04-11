using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(TestScript))]
public class HideInspector : Editor
{
    override public void OnInspectorGUI()
    {
        var myScript = target as TestScript;

        using (new EditorGUI.DisabledScope(myScript.Warrior))
        {
            myScript.Mage = EditorGUILayout.Toggle("Mage", myScript.Mage);

            using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(myScript.Mage)))
            {
                if (group.visible == true)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PrefixLabel("Player Color");
                    myScript.PlayerColor = EditorGUILayout.ColorField(myScript.PlayerColor);
                    EditorGUILayout.PrefixLabel("Player Name");
                    myScript.Name = EditorGUILayout.TextField(myScript.Name);
                    //-----------------------------------------------
                    EditorGUILayout.PrefixLabel("Hide Info");
                    myScript.DisableTest = EditorGUILayout.Toggle(myScript.DisableTest);
                    //-----------------------------------------------
                    using (new EditorGUI.DisabledScope(myScript.DisableTest))
                    {
                        myScript.Age = EditorGUILayout.IntField("Age", myScript.Age);
                        myScript.Weight = EditorGUILayout.FloatField("Weight", myScript.Weight);
                        myScript.Height = EditorGUILayout.FloatField("Height", myScript.Height);
                    }
                    EditorGUI.indentLevel--;
                }
            }
        }

        using (new EditorGUI.DisabledScope(myScript.Mage))
        {
            myScript.Warrior = EditorGUILayout.Toggle("Warrior", myScript.Warrior);

            using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(myScript.Warrior)))
            {
                if (group.visible == true)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PrefixLabel("Player Color");
                    myScript.PlayerColor = EditorGUILayout.ColorField(myScript.PlayerColor);
                    EditorGUILayout.PrefixLabel("Player Name");
                    myScript.Name = EditorGUILayout.TextField(myScript.Name);
                    //-----------------------------------------------
                    EditorGUILayout.PrefixLabel("Enable Default Stats");
                    myScript.DisableTest = EditorGUILayout.Toggle(myScript.DisableTest);
                    //-----------------------------------------------
                    using (new EditorGUI.DisabledScope(myScript.DisableTest))
                    {
                        myScript.WarriorStats = EditorGUILayout.Vector3Field("Stats", myScript.WarriorStats);
                    }
                    EditorGUI.indentLevel--;
                }
            }
        }
    }
}
