using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(PathManager))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PathManager script = (PathManager)target;

        if (GUILayout.Button("Create New Point"))
        {
            script.CreateNewPoint();
        }

        if (GUILayout.Button("Remove Last Point"))
        {
            script.RemoveLastPoint();
        }

        if (GUILayout.Button("Clear Point List"))
        {
            script.ClearPointList();
        }
    }

    private void OnSceneGUI()
    {
        PathManager script = (PathManager)target;

        if (script.StartPoint == null || script.EndPoint == null)
        {
            Debug.LogWarning("Start or end point is not set!");
            return;
        }

        Handles.color = Color.green;

        if (script.Points.Count <= 0)
        {
            Handles.DrawLine(script.StartPoint.position, script.EndPoint.position);
            return;
        }

        Handles.DrawLine(script.StartPoint.position, script.Points[0].transform.position);

        for (int i = 0; i < script.Points.Count - 1; i++)
        {
            if (script.Points[i] != null && script.Points[i + 1] != null)
            {
                Handles.DrawLine(script.Points[i].transform.position, script.Points[i + 1].transform.position);
            }
        }

        Handles.DrawLine(script.Points[script.Points.Count - 1].transform.position, script.EndPoint.position);
    }
}
#endif

