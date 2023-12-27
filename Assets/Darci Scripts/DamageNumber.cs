using System.Collections;
using System.Threading;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HurtValueAnim : MonoBehaviour {
    RectTransform rectTransform;

    public Vector2 delta;
    public float timeToShow;
    public float waitTime;
    public float timeToFade;
    public float scale;

    void Start() {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.DOLocalMove(new Vector3(rectTransform.anchoredPosition.x + delta.x, rectTransform.anchoredPosition.y + delta.y, 0), timeToShow);
        rectTransform.DOScale(new Vector3(scale, scale, scale), timeToShow);
        GetComponent<Text>().DOFade(1, timeToShow);

        StartCoroutine(WaitForASecond(waitTime));
    }

    IEnumerator WaitForASecond(float waitTime) {
        float timer = 0f;

        while (timer < waitTime) {
            yield return null;
            timer += Time.deltaTime;
        }

        GetComponent<Text>().DOFade(0, timeToFade);

        yield return new WaitForSeconds(timeToFade);

        Destroy(gameObject);
    }
}