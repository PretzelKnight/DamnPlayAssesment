using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public delegate void MethodDelegate();

[RequireComponent(typeof(CanvasGroup))]
public class FadeOption : MonoBehaviour
{
    [SerializeField] float fadeTime = 0.2f;
    [SerializeField] float delay = 0f;

    protected CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        if (group != null)
            return;

        group = GetComponent<CanvasGroup>();
    }

    public virtual void SnapActive(bool active)
    {
        if (group == null)
            Start();

        group.DOKill();
        if (active)
        {
            gameObject.SetActive(true);
            group.alpha = 1f;
        }
        else
        {
            gameObject.SetActive(false);
            group.alpha = 0;
        }
    }

    public virtual void FadeActive(bool active)
    {
        if (group == null)
            Start();

        group.DOKill();
        if (active)
        {
            if (gameObject.activeSelf)
                return;
            gameObject.SetActive(true);
            group.DOFade(1f, fadeTime * (1f - group.alpha));
        }
        else
        {
            if (!gameObject.activeSelf)
                return;
            group.DOFade(0, fadeTime * group.alpha).OnComplete(() => gameObject.SetActive(false));
        }
    }

    public virtual void DelayedFadeActive(bool active)
    {
        if (group == null)
            Start();

        group.DOKill();
        StopAllCoroutines();
        StartCoroutine(DelayCoroutine(() => FadeActive(active)));
    }

    IEnumerator DelayCoroutine(MethodDelegate del)
    {
        yield return new WaitForSeconds(delay);
        del.Invoke();
    }
}