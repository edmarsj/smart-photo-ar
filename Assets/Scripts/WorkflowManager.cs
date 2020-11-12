using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public static class WorkflowManager
{
    public static SessionData session = new SessionData();


    public static void TakePhotos()
    {
        SceneManager.LoadScene("Camera");
    }

    public static void SelectPhotos()
    {       
        SceneManager.LoadScene("PhotoSelect");
    }

    public static void AddPosition(PhotoPosition position)
    {
        session.Photos.Add(new PhotoData
        {
            PositionName = position.name,
            PositionObject = position
        });
    }

    public static void RemovePosition(PhotoPosition position)
    {
        session.Photos.RemoveAll(m => m.PositionName == position.name);
    }

}
