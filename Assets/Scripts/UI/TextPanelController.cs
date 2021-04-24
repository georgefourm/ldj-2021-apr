using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelController : MonoBehaviour
{
    public Text textRef;

    public TextAsset textAsset;

    public float Speed = 20;

    string text;

    bool completed = false;

    IEnumerator coroutine;

    private void Start()
    {
        text = textAsset.text;
        coroutine = writeText();
        StartCoroutine(coroutine);
    }

    protected IEnumerator writeText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textRef.text = text.Substring(0, i);

            yield return new WaitForSeconds(1/Speed);
        }
        completed = true;
    }

    public void Skip()
    {
        if (completed)
        {
            GameManager.Instance.ToggleMovement();
            Destroy(gameObject);
        }
        else
        {
            StopCoroutine(coroutine);
            textRef.text = text;
            completed = true;
        }
    }
}
