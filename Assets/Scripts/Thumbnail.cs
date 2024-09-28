using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Thumbnail : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text rating;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text pricing;
    [SerializeField] Color color;

    [Space]

    [SerializeField] Color good;
    [SerializeField] Color medium;
    [SerializeField] Color bad;
    [SerializeField, Range(0,5)] float goodBench;
    [SerializeField, Range(0,5)] float mediumBench;

    protected ThumbnailInfo info;

    public void ApplyInfo(ThumbnailInfo info)
    {
        this.info = info;
        name.text = info.title;
        rating.text = info.rating.ToString();

        if (info.rating >= goodBench)
            rating.color = good;
        else if (info.rating >= mediumBench)
            rating.color = medium;
        else
            rating.color = bad;

        description.text = info.description;
        float newPrice = info.price * (1f - info.discountPercentage / 100f);
        newPrice = RoundToNearestDecimal(newPrice, 2);
        pricing.text = "<s>" + info.price.ToString() + "</s> " + "<color=#"+ ColorUtility.ToHtmlStringRGB(color) +">" + newPrice.ToString() + "$</color>";
    }

    float RoundToNearestDecimal(float num, int decimalPlaces)
    {
        num = num * Mathf.Pow(10, decimalPlaces);
        num = Mathf.Round(num);
        num = num / Mathf.Pow(10, decimalPlaces);
        return num;
    }

    public RawImage RawImage => image; 
}