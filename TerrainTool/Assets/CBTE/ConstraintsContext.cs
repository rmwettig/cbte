using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the user access point to control active constraints
/// </summary>
[ExecuteInEditMode]
public class ConstraintsContext : MonoBehaviour
{
    private Terrain _terrain;
    private TextureSourceManager _tsm;
    [SerializeField]
    private List<Constraint> _constraints = new List<Constraint>(1);
    private bool _noError = false;
    public TextureSourceManager TextureSourceManager { get { return _tsm; } }

    public List<Constraint> Constraints { get { return _constraints; } }
    public Terrain Terrain { get { return _terrain; } }
    private void OnEnable()
    {
        _terrain = GetComponent<Terrain>();
        if (_terrain == null)
        {
            Debug.LogError("Missing Terrain! Constraints cannot be used without a Unity terrain.");
        }
        else
        {
            if (_tsm == null)
            {
                _tsm = ScriptableObject.CreateInstance<TextureSourceManager>();
                UserTexture ut = ScriptableObject.CreateInstance<UserTexture>();
                ut.SetName("UserTexture");
                _tsm.AddPrototypes(ut);
            }
            _noError = true;
        }

    }

    private void OnDisable()
    {

    }
    /// <summary>
    /// Render constraint representations in the scene view
    /// </summary>
    public void OnDrawGizmosSelected()
    {
        if (!_noError) return;
        foreach (Constraint c in _constraints)
        {
            c.DrawGizmo();
        }
    }

}

