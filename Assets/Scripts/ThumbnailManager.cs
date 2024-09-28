using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbnailManager : GetAPIInfo<ThumbnailInfoList>
{
    [SerializeField] Transform contentParent;
    [SerializeField] Thumbnail prefab;

    protected override void OnFetch(ThumbnailInfoList info)
    {
        foreach (var productinfo in info.products)
        {
            Thumbnail temp = Instantiate(prefab, contentParent);
            temp.ApplyInfo(productinfo);
            GetImage(temp.RawImage, productinfo.thumbnail);
        }
    }
}

[System.Serializable]
public class ThumbnailInfoList
{
    public List<ThumbnailInfo> products;
}

[System.Serializable]
public class ThumbnailInfo
{
    public string title;
    public float rating;
    public string description;
    public float price;
    public float discountPercentage;
    public string thumbnail;
}