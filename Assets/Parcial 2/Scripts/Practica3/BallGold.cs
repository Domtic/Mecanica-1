using UnityEngine.EventSystems;
using UnityEngine;
[RequireComponent(typeof(DragGolf))]
public class BallGold : MonoBehaviour
{
    public DragGolf drag = null;

    private void Awake()
    {
        drag = GetComponent<DragGolf>();
        drag.onBeginDrag += delegate (PointerEventData data)
        {
            Debug.Log("arrastrando bola");
        };
    }
}
