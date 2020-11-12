using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PhotoSelectScene : MonoBehaviour
{

    [SerializeField] private Button btnNext;

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
                Debug.Log(photoTaken.PositionObject);
            }

            var button = buttons.Single(b => b.position == photoTaken.PositionObject);
            button.Selected = true;
        }

        btnNext.interactable = WorkflowManager.session.Photos.Any();
    }

    private void OnEnable()
    {
        WorkflowManager.OnItemSelectedChange += WorkflowManager_OnItemSelectedChange;
    }

    private void OnDisable()
    {
        WorkflowManager.OnItemSelectedChange -= WorkflowManager_OnItemSelectedChange;
    }

    private void WorkflowManager_OnItemSelectedChange(bool hasItemsSelected)
    {
        btnNext.interactable = hasItemsSelected;
    }
    

    public void Next()
    {
        WorkflowManager.TakePhotos();
    }

    public void Back()
    {
        WorkflowManager.Wellcome();
    }

   

}
