using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhotoSelectScene : MonoBehaviour
{
    public void Next()
    {
        WorkflowManager.TakePhotos();
    }

    private void Start()
    {
        var buttons = transform.GetComponentsInChildren<ButtonBehaviour>();

        foreach (var btn in buttons)
        {
            btn.Selected = false;
        }

        foreach (var photoTaken in WorkflowManager.session.Photos)
        {
            // Restore asset
            if (photoTaken.PositionName != null && photoTaken.PositionObject == null)
            {
                photoTaken.PositionObject = Resources.Load<PhotoPosition>(photoTaken.PositionName);
            }

            var button = buttons.Single(b => b.position == photoTaken.PositionObject);
            button.Selected = true;
        }


    }

}
