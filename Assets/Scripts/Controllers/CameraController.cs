using UnityEngine;


namespace Asteroids
{
    public class CameraController : MonoBehaviour, IController
    {
        [SerializeField] [Range (0f, 1f)] private float _lerpValue;
        [SerializeField] private Player _player;
        [SerializeField] private Vector3 _cameraOffset;
        private Camera _camera;
        private Vector3 direction;
        private Quaternion rotation;

        private void Start()
        {
            _camera = Camera.main;
        }
        public void Updater()
        {
            _camera.transform.position = Vector3.Lerp(
                                                    _camera.transform.position, 
                                                    _player.transform.position + _cameraOffset, 
                                                    _lerpValue);
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotation = _player.transform.rotation;
        }
    }
}
