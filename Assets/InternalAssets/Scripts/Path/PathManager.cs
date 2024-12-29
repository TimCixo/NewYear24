using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PathView))]
public class PathManager : MonoBehaviour
{
    private PathModel _model;
    private PathView _view;
    private PathPresenter _presenter;

    [Header("Spawned Prefabs")]
    [Tooltip("List of added prefabs.")]
    public List<GameObject> Points = new List<GameObject>();

    [Header("Prefab Settings")]
    [Tooltip("Start point for lines.")]
    public Transform StartPoint;
    [Tooltip("End point for lines.")]
    public Transform EndPoint;
    [Tooltip("Prefab that will be added to the scene.")]
    public GameObject Point;

    public PathPresenter Presenter => _presenter;

    private void Awake()
    {
        _model = new PathModel();

        ModelInit();

        _view = GetComponent<PathView>();
        _presenter = new PathPresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.StartPoint = StartPoint;
        _model.EndPoint = EndPoint;
        _model.Point = Point;
        _model.Points = Points;
    }
    
    public void CreateNewPoint()
    {
        if (Point == null)
        {
            Debug.LogError("Prefab is not set!");
            return;
        }

        GameObject newPrefab = Instantiate(Point, transform.position, Quaternion.identity, transform);

        Points.Add(newPrefab);
        EditorUtility.SetDirty(this);
    }

    public void RemoveLastPoint()
    {
        if (Points.Count > 0)
        {
            GameObject lastPrefab = Points[Points.Count - 1];

            Points.RemoveAt(Points.Count - 1);
            DestroyImmediate(lastPrefab);
        }
        else
        {
            Debug.LogWarning("No objects to remove!");
        }
        EditorUtility.SetDirty(this);
    }

    public void ClearPointList()
    {
        foreach (GameObject prefab in Points)
        {
            if (prefab != null)
            {
                DestroyImmediate(prefab);
            }
        }

        Points.Clear();
        EditorUtility.SetDirty(this);
    }
}