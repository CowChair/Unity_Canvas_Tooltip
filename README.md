# Unity Responsive Tooltip

## Video (YouTube - Responsive Tooltip for Unity)
[![Responsive Tooltip](https://img.youtube.com/vi/#VIDEOID#/0.jpg)](https://www.youtube.com/watch?v=VIDEOID)

## Overview

This project is a single script example for a responsive tooltip. For it to be responsive, the tooltip uses the cursor's current quadrant to offset the Rect Transform's anchored Position.

## Setup

For the project example, I used an empty Rect Transform and a couple of visual components. For the script to work correctly, ensure it's on the appropriate parent object and has centered anchor points.

## Code
I've provided a sample project, but this is the script in its entirety.

```
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private RectTransform RectTransform => transform as RectTransform;
    private Vector2 HalfRect => RectTransform.rect.size / 2.0f;

    private void Update()
    {
        UpdatePosition();
        UpdateOffset();
    }

    private void UpdatePosition()
    {
        transform.position = Input.mousePosition;
    }

    private void UpdateOffset()
    {
        RectTransform.anchoredPosition -= HalfRect * FindScreenQuadrant();
    }

    private Vector2Int FindScreenQuadrant()
    {
        Vector2Int screenQuadrant = Vector2Int.zero;

        screenQuadrant.x = (int)Mathf.Round(Input.mousePosition.x / Screen.width);
        screenQuadrant.y = (int)Mathf.Round(Input.mousePosition.y / Screen.height);

        screenQuadrant.x = screenQuadrant.x == 0 ? -1 : 1;
        screenQuadrant.y = screenQuadrant.y == 0 ? -1 : 1;

        return screenQuadrant;
    }
}
```

## Approach

The idea behind this approach is that it simply offsets the Tooltip's Rect Transform, keeping the cursor between it and the edge of the window.

## Important Bits

This code rounds the cursor position to either `0` or `1`.
```
screenQuadrant.x = (int)Mathf.Round(Input.mousePosition.x / Screen.width);
screenQuadrant.y = (int)Mathf.Round(Input.mousePosition.y / Screen.height);
```

This code then retains the `1` or converts the `0` to `-1`.
```
screenQuadrant.x = screenQuadrant.x == 0 ? -1 : 1;
screenQuadrant.y = screenQuadrant.y == 0 ? -1 : 1;
```

## End
And, that's it! I hope you find this helpful.

-C

