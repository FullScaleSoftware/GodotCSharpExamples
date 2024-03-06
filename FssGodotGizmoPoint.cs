using Godot;
using System;

// FssGodotGizmoPoint creates a visual 3D point in the scene.
// This class extends Node3D and inherits its operations.
// - Use Show() and Hide() to control the visibility of the gizmo.
// - Modify the Scale property to adjust the size of the gizmo in 3D space.
// Remember, scaling affects the entire node uniformly.

public class FssGodotGizmoPoint : Node3D
{
    private Color _color = new Color(1.0f, 0.0f, 0.0f); // Default color: red
    private float _radius = 0.1f; // Default size of the dot
    private MeshInstance3D _meshInstance;

    public FssGodotGizmoPoint(Color color, float size)
    {
        _color = color;
        _radius = size;
    }
  
    public override void _Ready()
    {
        CreatePoint();
    }

    private void CreatePoint()
    {
        var mesh = new SphereMesh
        {
            Radius = _radius,
            RadialSegments = 16,
            Rings = 16
        };

        var material = new StandardMaterial3D
        {
            AlbedoColor = _color,
            Unshaded = true
        };

        _meshInstance = new MeshInstance3D
        {
            Mesh = mesh,
            MaterialOverride = material,
        };

        AddChild(_meshInstance);
    }

    public void UpdateColor(Color newColor)
    {
        _color = newColor;
        if (_meshInstance.MaterialOverride is StandardMaterial3D material)
        {
            material.AlbedoColor = _color;
        }
    }

    public void UpdateRadius(float newRadius)
    {
        _radius = newRadius;
        if (_meshInstance.Mesh is SphereMesh sphereMesh)
        {
            sphereMesh.Radius = _radius;
        }
    }
}
