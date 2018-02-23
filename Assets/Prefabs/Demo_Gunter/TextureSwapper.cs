using System;                               // String.Split()
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TextureSwapper : MonoBehaviour {

    public TextAsset TimeToTextureTable;    // text file containing one float per line
    public VRTK_ControllerEvents controllerEvents;
    public Animator animator;

    private AudioSource audioSource;
    private Renderer rend;

    private List<float> seconds;            // list of times. At time[n], load texture[n].
    private UnityEngine.Object[] pngs;      // array of textures.

    private int lastIndex;                  // texture[n]: most recent n

    private bool animationPlayable = false;

    // Use this for initialization
    void Start () {
        parseKeyFramesFromTextFile();       // populate the list 'seconds' with float values from file
        pngs = Resources.LoadAll("Frames", typeof(Texture));        

        rend = GetComponentInChildren<Renderer>();
        animator.enabled = false;

        controllerEvents.GripPressed += StartAnimation;
    }

    private void StartAnimation(object sender, ControllerInteractionEventArgs e)
    {
        animator.enabled = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        animationPlayable = true;
    }

    // Update is called once per frame
    void Update () {
        if (animationPlayable)
        {
            var index = seconds.FindIndex(keyframe => keyframe > audioSource.time);
            if (index == lastIndex) return;         // nothing to change; abort.
            lastIndex = index;

            rend.material.mainTexture = pngs[index] as Texture;

            //Debug.Log(audioSource.time + "s: loaded " + pngs[index].name);
        }
    }

    void parseKeyFramesFromTextFile()
    {
        seconds = new List<float>();

        // source: https://stackoverflow.com/questions/3989816/reading-a-string-line-per-line-in-c-sharp
        foreach (var line in TimeToTextureTable.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            seconds.Add(float.Parse(line));
        }
    }
}
