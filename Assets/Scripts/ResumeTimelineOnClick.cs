using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ResumeTimelineOnClick : MonoBehaviour
{
    public PlayableDirector director;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(ResumeTimeline);
    }

    public void ResumeTimeline()
    {
        Debug.Log("clicked");
        director.Play();
    }
}