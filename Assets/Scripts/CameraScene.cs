using UnityEngine;
using System.Linq;
using TMPro;

public class CameraScene : MonoBehaviour
{
    private int CurrentPhoto;
    public TMP_Text title;


    public GhostManager ghost;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPhoto = 0;
        PositionToTakePhoto();

    }

    public void Back()
    {
        CurrentPhoto--;
        if (CurrentPhoto < 0)
        {
            WorkflowManager.SelectPhotos();
        }

        PositionToTakePhoto();
    }

    public void Next()
    {
        CurrentPhoto++;
        if (CurrentPhoto >= WorkflowManager.session.Photos.Count())
        {
            WorkflowManager.SelectPhotos();
        }

        PositionToTakePhoto();
    }

    private void PositionToTakePhoto()
    {
        var total = WorkflowManager.session.Photos.Count();
        title.text = $"Take photo {CurrentPhoto + 1} of {total}";
        ghost.SetPosition(WorkflowManager.session.Photos[CurrentPhoto].PositionObject);
    }
}
