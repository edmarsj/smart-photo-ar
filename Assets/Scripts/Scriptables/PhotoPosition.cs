using UnityEngine;

[CreateAssetMenu(menuName = "PartsTrader/PhotoPosition", fileName = "PhotoPosition")]
public class PhotoPosition : ScriptableObject
{
    public string description;
    public Vector3 position;
    public Vector3 rotation;
}
