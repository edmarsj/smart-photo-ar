using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSelectScene : MonoBehaviour
{
    public void Next()
    {
        WorkflowManager.TakePhotos();
    }

}
