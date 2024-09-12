using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicClip
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public AudioClip Clip { get; private set; }
    public double ClipLength;
    [field: SerializeField] public bool Loop { get; private set; }
    [field: SerializeField] public string NextClip { get; private set; }
    [field: SerializeField] public double BPM { get; private set; }
    public int Beats => (int)(ClipLength / BPM);
    public double BPMInSecons => 60.0 / BPM;
}
