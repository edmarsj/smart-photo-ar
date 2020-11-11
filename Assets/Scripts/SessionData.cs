using System;
using System.Collections.Generic;

[Serializable]
public class SessionData
{
    public string Rego;
    public List<PhotoData> Photos = new List<PhotoData>();
}

[Serializable]
public class PhotoData
{
    public string PositionName;
    public string FileName;

    public PhotoPosition PositionObject { get; set; }
}