using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    [SerializeField] private Transform follow;
    [SerializeField] private Vector3 offset;

    private void Update() {
        transform.position = follow.position + offset;
    }
}
