using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelController : MonoBehaviour
{
    public Text textRef;

    public TextAsset textAsset;

    public float CharsPerSec = 20;

    string text;

    bool completed = false;

    IEnumerator coroutine;

    private void Awake()
    {
        text = textAsset.text;
    }

    public void StartText()
    {
        gameObject.SetActive(true);
        gameObject.SetActive(true);
        coroutine = writeText();
        StartCoroutine(coroutine);
    }

    protected IEnumerator writeText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textRef.text = text.Substring(0, i);

            yield return new WaitForSeconds(1/CharsPerSec);
        }
        completed = true;
    }

    public void Skip()
    {
        if (completed)
        {
            GameManager.Instance.StartLevel();
            gameObject.SetActive(false);
            completed = false;
        }
        else
        {
            StopCoroutine(coroutine);
            textRef.text = text;
            completed = true;
        }
    }
}
