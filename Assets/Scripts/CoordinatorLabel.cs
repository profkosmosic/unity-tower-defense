using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]
public class CoordinatorLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    [SerializeField]Color defaultColor = Color.white;
    [SerializeField]Color blockedColor = Color.black;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying) {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    void ToggleLabels() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.enabled;
        }
    }

    void ColorCoordinates() {
        if(waypoint.IsPlacable) {
            label.color = defaultColor;
        }
        else label.color = blockedColor;
    }

    void DisplayCoordinates() {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 10);
        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
}
