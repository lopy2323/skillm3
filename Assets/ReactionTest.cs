using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTest : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;
    [SerializeField] TextMeshProUGUI StopWatch;

    enum State { idle, wait, play, stop};
    State myState = State.play;

    float time = 0f;

    void Start()
    {
        StartButton.onClick.AddListener(ClickStartButton);
        StopButton.onClick.AddListener(ClickStopButton);
        ContinueButton.onClick.AddListener(ClickContiueButton);

        StopWatch.text = "StopWatch";
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == State.play) 
        {
            time = time + Time.deltaTime; 
        }


        StopWatch.text = time.ToString("F2");
        
    }

    private void ClickStartButton()
    {
        //
    }

    private void ClickStopButton()
    {
        myState = State.stop;
    }

    private void ClickContiueButton()
    {
        //
    }
}
