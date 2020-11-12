using UnityEngine;
using UnityEngine.UI;

public class PhotoReviewScene : MonoBehaviour
{
    [SerializeField] private RawImage photo;

    private void Start()
    {
        photo.texture = WorkflowManager.ImageToReview;
    }

    public void Next()
    {
        var date = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        var fileName = string.Format("{0}{1}.png", WorkflowManager.session.Rego, WorkflowManager.session.Photos[WorkflowManager.CurrentPhoto].PositionName);

        NativeGallery.SaveImageToGallery(
                WorkflowManager.ImageToReview, Application.productName, fileName);

        WorkflowManager.ImageToReview = null;

        WorkflowManager.session.Photos[WorkflowManager.CurrentPhoto].FileName = fileName;
        WorkflowManager.CurrentPhoto++;

        if (WorkflowManager.CurrentPhoto >= WorkflowManager.session.Photos.Count)
        {
            WorkflowManager.Finish();
            return;
        }

        WorkflowManager.TakePhotos();
    }

    public void Back()
    {

    }
}

