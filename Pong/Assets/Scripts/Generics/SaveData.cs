using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float MusicValue = 1;
    public float SFXValue = 1;
    public Dictionary<string, float> AudioSettings = new Dictionary<string, float>();
}
