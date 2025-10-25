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
