using Cinemachine;
using Game.Plants.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Presentation
{
    public class CameraTarget : MonoBehaviour
    {
        [Header("Zooming")]
        [SerializeField] private float minRange;
        [SerializeField] private float maxRange;

        [SerializeField] private float zoomSpeed;
        
        [Header("References")]
        [SerializeField] private Camera realCamera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        
        [Header("Other")]
        [SerializeField] private LayerMask groundLayer;

        private CinemachineFramingTransposer _transposer;

        private IPlantUI _plantUI;
        
        [Inject]
        private void Construct(IPlantUI plantUI)
        {
            _plantUI = plantUI;
        }

        private void Update()
        {
            if (_plantUI.IsActive) return;
            
            if (Input.GetMouseButtonDown(1))
            {
                var mousePosition = Input.mousePosition;
                var ray = realCamera.ScreenPointToRay(mousePosition);

                var cast = Physics.Raycast(ray, out var hitInfo, float.MaxValue, groundLayer.value);
                if (cast)
                {
                    transform.position = hitInfo.point;
                }
            }

            var delta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            
            _transposer ??= virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer;
            
            var value = Mathf.Clamp(_transposer.m_CameraDistance - delta, minRange, maxRange);
            _transposer.m_CameraDistance = value;
        }
    }
}