using UnityEngine;

    public class HexWorldGrid
    {
        // Cosine of a 30 degree angle
        private const float cos30 = 0.866025404f;
        // Distance from the center of a hex to any edge of the hex.
        private float distanceToEdge;
        // Distance between the centers of two hexes.
        private float DistanceBetweenCenter => 2 * distanceToEdge;
        // Radius of each hexagon (distance from center to a vertex).
        private float hexRadius;
        // Base position for this tile map.
        private Transform basePosition;

        // Create a hex grid with a given tile map.
        /// <param name="hexRadius">Radius of hexagon, distance from center to vertex.</param>
        /// <param name="basePosition">Base position of the square grid.</param>
        public HexWorldGrid(float hexRadius, Transform basePosition)
        {
            this.basePosition = basePosition;
            this.hexRadius = hexRadius;
            // Compute distance from center of hex to any edge
            distanceToEdge = cos30 * hexRadius;
        }

        public Vector3 GetWorldPosition(Vector2Int loc)
        {
            bool evenRow = loc.y % 2 == 0;
            // Offset hexes within a row by twice the distance to an edge
            // Offset even and odd rows by the distance to an edge of a hex in the grid
            float offsetX = DistanceBetweenCenter * loc.x + (evenRow ? 0 : distanceToEdge);
            // Offset hexes in consecutive rows by 1.5 times the hexagon radius
            float offsetY = (hexRadius * 1.5f) * loc.y;
            return basePosition.TransformPoint(offsetX, 0, offsetY);
        }
        
        public Quaternion GetWorldRotation(Vector2Int loc) => basePosition.rotation;
    }