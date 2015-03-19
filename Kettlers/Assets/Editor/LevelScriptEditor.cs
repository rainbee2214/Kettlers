using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DisplaySlider))]
public class LevelScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DisplaySlider displaySlider = (DisplaySlider)target;

        EditorGUILayout.LabelField("Level", displaySlider.Level.ToString());
    }
}
