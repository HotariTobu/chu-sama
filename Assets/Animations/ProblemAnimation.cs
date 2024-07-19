using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemAnimation : MonoBehaviour
{
    [SerializeField] public float StartScale = 1;
    [SerializeField] public float EndScale = 2;
    [SerializeField] public float StartOpacity = 0;
    [SerializeField] public float EndOpacity = 1;
    [SerializeField] public float Duration = 15;

    private Dictionary<Text3D, Coroutine> _coroutines = new();

    public void StartAnimation(Text3D problemText)
    {
        if (_coroutines.ContainsKey(problemText))
        {
            return;
        }

        var coroutine = StartCoroutine(UpdateAnimation(problemText));
        _coroutines.Add(problemText, coroutine);
    }

    public void StopAnimation(Text3D problemText)
    {
        if (_coroutines.TryGetValue(problemText, out Coroutine coroutine))
        {
            StopCoroutine(coroutine);
            _coroutines.Remove(problemText);
        }
    }

    private IEnumerator UpdateAnimation(Text3D problemText)
    {
        var elapsedTime = 0f;
        while (elapsedTime < Duration)
        {
            elapsedTime += Time.deltaTime;
            var t = elapsedTime / Duration;

            problemText.Scale = Mathf.Lerp(StartScale, EndScale, t);
            problemText.Opacity = Mathf.Lerp(StartOpacity, EndOpacity, t);

            yield return null;
        }
    }
}