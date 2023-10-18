using UnityEngine;
using UnityEngine.Playables;

public class PauseTimeline : MonoBehaviour
{
    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.Pause();
    }
}