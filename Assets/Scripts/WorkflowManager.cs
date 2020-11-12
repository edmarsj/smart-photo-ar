using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void NotifySelectedChanged(bool hasItemsSelected);

public static class WorkflowManager
{
    public static SessionData session = new SessionData();
    public static Texture2D ImageToReview;
    public static int CurrentPhoto;

    public static event NotifySelectedChanged OnItemSelectedChange;

    internal static void NewSession(string text)
    {
        session = new SessionData()
        {
            Rego = text
        };

        SceneManager.LoadScene("PhotoSelect");
    }

    public static void TakePhotos()
    {       
        for (var i = 0; i < session.Photos.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(session.Photos[i].FileName))
            {
                CurrentPhoto = i;
                break;
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

        SceneManager.LoadScene("Wellcome");
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

        OnItemSelectedChange?.Invoke(session.Photos.Count > 0);
    }

    public static void RemovePosition(PhotoPosition position)
    {
        session.Photos.RemoveAll(m => m.PositionName == position.name);

        OnItemSelectedChange?.Invoke(session.Photos.Count > 0);
    }

    internal static void Finish()
    {
        CurrentPhoto = 0;
        SceneManager.LoadScene("Finish");
    }

    internal static void Wellcome()
    {
        SceneManager.LoadScene("Wellcome");
    }

   

    public static void ReviewPhoto(Texture2D image)
    {
        ImageToReview = image;
        SceneManager.LoadScene("PhotoReview");
    }
    
}
