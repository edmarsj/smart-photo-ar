using UnityEngine;
using System.Linq;
using TMPro;

public class CameraScene : MonoBehaviour
{    
    public TMP_Text title;


    public GhostManager ghost;
    // Start is called before the first frame update
    void Start()
    {        
        PositionToTakePhoto();
    }

    public void Back()
    {
        WorkflowManager.CurrentPhoto--;
        if (WorkflowManager.CurrentPhoto < 0)
        {
            WorkflowManager.SelectPhotos();
            return;
        }

        PositionToTakePhoto();
    }

    public void Next()
    {
        WorkflowManager.CurrentPhoto++;
        if (WorkflowManager.CurrentPhoto >= WorkflowManager.session.Photos.Count())
        {
            WorkflowManager.Finish();
            return;
        }

        PositionToTakePhoto();
    }

    private void PositionToTakePhoto()
    {
        var total = WorkflowManager.session.Photos.Count();
        title.text = $"Align photo with silhouette - {WorkflowManager.CurrentPhoto + 1} of {total}";
        ghost.SetPosition(WorkflowManager.session.Photos[WorkflowManager.CurrentPhoto].PositionObject);
    }

    public void ReviewPhoto(Texture2D image)
    {
        //var date = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        //var fileName = string.Format("{0}{1}.png", Application.productName, date);

        //NativeGallery.SaveImageToGallery(
        //        image, Application.productName, fileName);

        //WorkflowManager.session.Photos[CurrentPhoto].FileName = fileName;

        WorkflowManager.ReviewPhoto(image);

        //var texture = NativeGallery.LoadImageAtPath(WorkflowManager.session.Photos[CurrentPhoto].FileName);
    }
}
