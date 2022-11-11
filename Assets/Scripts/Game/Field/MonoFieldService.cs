using System;
using System.Collections.Generic;
using Game.Farmer.Interfaces;
using Game.Field.Interfaces;
using Game.Plants;
using Game.Plants.Enums;
using Game.Plants.Interfaces;
using Game.Presentation;
using UnityEngine;
using Zenject;

namespace Game.Field
{
    public class MonoFieldService : MonoBehaviour, IFieldService
    {
        public event Action<Vector2Int> OnCellClicked = _ => { };

        [Header("General")]
        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private Vector2 cellSize;

        [Header("References")] 
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private Transform cellRoot;

        [Header("Debug")]
        [SerializeField] private bool drawGizmos;

        private readonly IDictionary<Vector2Int, CellView> _cells = new Dictionary<Vector2Int, CellView>();

        private bool _canInteract = true;

        private IPlantUI _plantUI;
        private IFactory<EPlantType, Vector3, PlantPresenter> _plantFactory;
        private IFarmerModel _farmerModel;
        private CameraTarget _cameraTarget;

        [Inject]
        private void Construct
        (
            IPlantUI plantUI, 
            IFactory<EPlantType, Vector3, PlantPresenter> plantFactory,
            IFarmerModel farmerModel,
            CameraTarget cameraTarget
        )
        {
            _plantUI = plantUI;
            _plantFactory = plantFactory;
            _farmerModel = farmerModel;
            _cameraTarget = cameraTarget;
        }

        public void Plant(EPlantType plant, Vector2Int position)
        {
            var realPosition = GetCellPosition(position);
            var instance = _plantFactory.Create(plant, realPosition);

            var cell = _cells[position];
            cell.HasPlant = true;
            
            _canInteract = true;
            
            cell.OnClick += Click;
            instance.OnRemoved += Remove;

            void Click()
            {
                var success = instance.Click();
                if (success)
                {
                    cell.OnClick -= Click;
                }
            }

            void Remove()
            {
                instance.OnRemoved -= Remove;
                cell.HasPlant = false;
            }
        }

        public Vector3 GetCellPosition(Vector2Int cell)
        {
            var anchor = new Vector3(-gridSize.x * cellSize.x / 2 + cellSize.x / 2, 0, -gridSize.y * cellSize.y / 2 + cellSize.y / 2);
            var position = anchor + new Vector3(cell.x * cellSize.x, 0, cell.y * cellSize.y);

            var result = transform.TransformPoint(position);
            return result;
        }

        public Vector2Int Size => gridSize;

        private void Fill(Vector2Int size)
        {
            Clear();
            
            for (var x = 0; x < size.x; x++)
            {
                for (var y = 0; y < size.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    var realPosition = GetCellPosition(position);
                    
                    var cell = Instantiate(cellPrefab, cellRoot);
                    cell.transform.position = realPosition;
                    cell.OnClick += Click;
                    
                    _cells.Add(position, cell);

                    void Click()
                    {
                        if (!_canInteract) return;
                        if (cell.HasPlant) return;
                        
                        _plantUI.Show();
                        _plantUI.OnPlantSelected += Select;

                        void Select(EPlantType type)
                        {
                            _plantUI.OnPlantSelected -= Select;
                            _plantUI.Hide();

                            _farmerModel.Plant(type, position);
                            _cameraTarget.transform.position = realPosition;

                            _canInteract = false;
                        }
                    }
                }
            }
        }

        private void Clear()
        {
            foreach (var (position, cell) in _cells)
            {
                Destroy(cell.gameObject);
            }
            
            _cells.Clear();
        }

        private void Start()
        {
            Fill(gridSize);
        }

        private void OnDrawGizmosSelected()
        {
            if (!drawGizmos) return;
            
            Gizmos.color = Color.green;
            for (var x = 0; x < gridSize.x; x++)
            {
                for (var y = 0; y < gridSize.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    var size = new Vector3(cellSize.x, 0.001f, cellSize.y);
                    
                    Gizmos.DrawWireCube(GetCellPosition(position), size);
                }
            }
        }

        [Serializable]
        private class PlantPrefab
        {
            public EPlantType Type;
            public MonoPlantView Plant;
        }
    }
}