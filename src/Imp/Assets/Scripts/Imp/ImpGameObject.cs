using UnityEngine;

namespace Imp
{
    internal class ImpGameObject : MonoBehaviour
    {
        [SerializeField] private LayerMask _dangerousTerrainLayers;
        [SerializeField] private LayerMask _warningTerrainLayers;

        public int _dangerousTerrainCounter;
        public int _warningTerrainCounter;

        public bool IsInWarningTerrain => _warningTerrainCounter > 0;
        public bool IsInDangerousTerrain => _dangerousTerrainCounter > 0;
        
        public Rigidbody2D Rigidbody2D;

        private void OnTriggerEnter2D(Collider2D col)
        {
            int objectLayer = col.gameObject.layer;
            if (IsCorrectLayer(_dangerousTerrainLayers, objectLayer))
                _dangerousTerrainCounter++;
            if (IsCorrectLayer(_warningTerrainLayers, objectLayer))
                _warningTerrainCounter++;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            int objectLayer = col.gameObject.layer;
            if (IsCorrectLayer(_dangerousTerrainLayers, objectLayer))
                _dangerousTerrainCounter--;
            if (IsCorrectLayer(_warningTerrainLayers, objectLayer))
                _warningTerrainCounter--;
        }

        private static bool IsCorrectLayer(LayerMask layerMask, int objectLayer)
        {
            return layerMask.value == (layerMask | (1 << objectLayer));
        }
    }
}