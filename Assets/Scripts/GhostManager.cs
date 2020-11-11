using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private Transform carSolid;
    [SerializeField] private Transform carGhost;
    [SerializeField] private PhotoPosition positionToPreview;

    public static GhostManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        Reset();
    }

    public void SetPosition(PhotoPosition position)
    {
        carSolid.transform.localRotation = Quaternion.Euler(position.rotation);
        carSolid.transform.localPosition = position.position;
        //        StartCoroutine(SmoothRotate(position.rotation));

    }

    private IEnumerator SmoothRotate(Vector3 targetRotation)
    {
        var duration = 1f;
        var time = 0f;
        while (time < duration)
        {
            time += .1f;
            var step = Vector3.Lerp(initialRotation, targetRotation, time);
            carSolid.transform.localRotation = Quaternion.Euler(step);
            yield return new WaitForSeconds(.04f);
        }
    }


    public void LoadPosition()
    {
        SetPosition(positionToPreview);
    }

    public void Reset()
    {
        carSolid.transform.localPosition = initialPosition;
        carSolid.transform.localRotation = Quaternion.Euler(initialRotation);
    }

#if UNITY_EDITOR

    [ContextMenu("Save")]
    public void SavePosition()
    {
        var asset = ScriptableObject.CreateInstance<PhotoPosition>();
        asset.rotation = carSolid.transform.rotation.eulerAngles;
        asset.position = carSolid.transform.localPosition;

        CreateAsset("NewPosition", asset);
    }

    public static void CreateAsset(string name, PhotoPosition asset)
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath($"{path}/Resources/{name}.asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
#endif
}
