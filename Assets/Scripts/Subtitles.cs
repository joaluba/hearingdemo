using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System.Text.RegularExpressions;

public class Subtitles : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string orig_text;
    private string[] thisSentences;
   

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        orig_text = textMeshPro.text;
        string[] sentences = SplitIntoSentences(orig_text);
        thisSentences = sentences;
        StartCoroutine(SubtitleSequence());

    }

    void OnEnable()
    {

        string[] sentences = SplitIntoSentences(orig_text);
        thisSentences = sentences;
        StartCoroutine(SubtitleSequence());

    }

    IEnumerator SubtitleSequence()
    {

        foreach (string sentence in thisSentences)
        {
            string seconds = sentence.Substring(sentence.Length - 2, 1);
            textMeshPro.text= sentence.Substring(0, sentence.Length - 2);
            yield return new WaitForSeconds(float.Parse(seconds));
            //Debug.Log(sentence);
        }


        textMeshPro.text ="";

    }

    string[] SplitIntoSentences(string text)
    {
        // Define a regular expression to match sentence-ending punctuation
        Regex sentenceRegex = new Regex(@"(?<=[/])\s+");

        // Split the text using the regular expression
        string[] sentences = sentenceRegex.Split(text);

        return sentences;
    }
}
