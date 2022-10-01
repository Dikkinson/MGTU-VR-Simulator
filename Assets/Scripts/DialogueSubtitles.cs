using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSubtitles : MonoBehaviour
{
    private Text subtitlesText;

    CompositeDisposable disposable = new CompositeDisposable();

    private void OnEnable()
    {
        DialogueSystem.StartDialogue.Subscribe(dialogue =>
        {
            subtitlesText.text = dialogue.DialogueText;
        }).AddTo(disposable);
        DialogueSystem.StopDialogue.Subscribe(_ =>
        {
            subtitlesText.text = "";
        }).AddTo(disposable);
    }

    private void OnDisable()
    {
        disposable.Clear();
    }

    private void Awake()
    {
        subtitlesText = GetComponent<Text>();
    }
}
