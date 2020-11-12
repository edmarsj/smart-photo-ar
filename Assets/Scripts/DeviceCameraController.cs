using System;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class DeviceCameraController : MonoBehaviour
{
    [SerializeField] private CameraScene cameraScene;

    private WebCamTexture phoneCamera;
    private GameObject surface;
    private void Awake()
    {
        surface = this.gameObject;
        phoneCamera = new WebCamTexture();
    }

    private void Start()
    {
#if !UNITY_EDITOR
        surface.GetComponent<Renderer>().material.mainTexture = phoneCamera;
        phoneCamera.Play();
#endif
    }

    public void TakePhoto()
    {
#if !UNITY_EDITOR
        Texture2D snap = new Texture2D(phoneCamera.width, phoneCamera.height);
        try
        {            
            snap.SetPixels(phoneCamera.GetPixels());
            snap.Apply();

            cameraScene.ReviewPhoto(snap);

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }    
#else
        cameraScene.ReviewPhoto(Resources.Load<Texture2D>("dummy"));
#endif
    }

}
