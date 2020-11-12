using System;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class DeviceCameraController : MonoBehaviour
{
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
        var date = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        var fileName = string.Format("{0}{1}.png", Application.productName, date);

        Texture2D snap = new Texture2D(phoneCamera.width, phoneCamera.height);
        try
        {
            snap.SetPixels(phoneCamera.GetPixels());
            snap.Apply();


            NativeGallery.SaveImageToGallery(
                snap, Application.productName, fileName);

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            Destroy(snap);
            //uiController.ShowToast();
        }
    }

}
