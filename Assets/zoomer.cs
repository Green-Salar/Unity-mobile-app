using UnityEngine;

public class zoomer : MonoBehaviour
{
    private Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            transform.localScale += new Vector3(deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f);
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, zoomOutMin, zoomOutMax), Mathf.Clamp(transform.localScale.y, zoomOutMin, zoomOutMax), Mathf.Clamp(transform.localScale.z, zoomOutMin, zoomOutMax));
        }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            //Vector2 touchOnePrevPos = touchOne.position
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStart = touchPos;
                    break;

                case TouchPhase.Moved:
                    transform.position = new Vector3(transform.position.x + (touchPos.x - touchStart.x), transform.position.y + (touchPos.y - touchStart.y), transform.position.z);
                    touchStart = touchPos;
                    break;

                case TouchPhase.Ended:
                    break;
            }
        }
    }
}