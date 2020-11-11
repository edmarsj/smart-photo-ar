#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GhostManager))]
public class GhostManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Save the current configurations as a new asset.", MessageType.Info);
        if (GUILayout.Button("Save Current"))
        {
            var ghostManager = (GhostManager)target;
            ghostManager.SavePosition();
        }

        EditorGUILayout.HelpBox("Load selected for preview.", MessageType.Info);
        if (GUILayout.Button("Load Selected"))
        {
            var ghostManager = (GhostManager)target;
            ghostManager.LoadPosition();
        }

        EditorGUILayout.HelpBox("Reset model to its defaults.", MessageType.Info);
        if (GUILayout.Button("Reset"))
        {
            var ghostManager = (GhostManager)target;
            ghostManager.Reset();
        }
    }
}
#endif