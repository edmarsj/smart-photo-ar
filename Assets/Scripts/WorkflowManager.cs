using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class WorkflowManager
{
    public static SessionData session = new SessionData();
    public static Texture2D ImageToReview;
    public static int CurrentPhoto;

    public static void TakePhotos()
    {
        session.Rego = "Test";

        for (var i = 0; i < session.Photos.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(session.Photos[i].FileName))
            {
                CurrentPhoto = i;
            }
        }
        SceneManager.LoadScene("Camera");
    }

    public static void Persist()
    {
        var fileName = $"{Application.persistentDataPath}/v1-{session.Rego}.json";
        string jsonContent = JsonUtility.ToJson(session, true);
        Debug.Log(jsonContent);

        File.WriteAllText(fileName,
                          jsonContent);

        Debug.Log(fileName);
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

    internal static void Finish()
    {
        CurrentPhoto = 0;
        SceneManager.LoadScene("Finish");
    }

    public static void RemovePosition(PhotoPosition position)
    {
        session.Photos.RemoveAll(m => m.PositionName == position.name);
    }

    public static void ReviewPhoto(Texture2D image)
    {
        ImageToReview = image;
        SceneManager.LoadScene("PhotoReview");
    }
}
