using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Ball prefabs.
    [SerializeField] public GameObject[] balls;
    // Diameter of a pool ball in units.
    [SerializeField] private float ballDiameter = 1.7f;
    /// Buffer of space between pool balls.
    [SerializeField] private float ballBuffer = 0.05f;
    /// Balls placed during setup.
    private List<GameObject> placedBalls = new List<GameObject>();

    public void Start()
    {
        SetupPoolBalls();
    }

    /// Clear out any previously placed balls and setup the 15 balls on the screen.
    public void SetupPoolBalls()
    {
        // Hide any previously placed balls.
        foreach (GameObject poolBall in placedBalls)
        {
            poolBall.SetActive(false);
        }
        // Clear out stale references.
        placedBalls.Clear();
        HexWorldGrid hexGrid = new HexWorldGrid(ballDiameter / 2 + ballBuffer, transform);

        // Layout balls
        // Save all positions in this grid
        List<Vector2Int> positions = Enumerable.Range(0, 5).SelectMany(
            row => Enumerable.Range(0, row + 1).Select(
                col => new Vector2Int(col - row / 2 - row % 2, row))).ToList();
        // Go through each of the remaining positions and place a random ball at each (without replacement)
        List<int> remaining = Enumerable.Range(1, 15).ToList();
        // Shuffle the remaining balls
        // For each remaining ball, place it at the given position
        var balls = positions.Zip(
            remaining.OrderBy(a => Random.Range(0, 100)),
            (pos, num) => PlacePoolBall(hexGrid, pos, num));
        // Add the placed balls ot the list of saved balls
        placedBalls.AddRange(balls);
    }

    /// <summary>
    /// Places a ball at a given position in the provided hex grid.
    /// </summary>
    /// <param name="hexGrid">Hex grid with positions of balls.</param>
    /// <param name="pos">Position ball is being placed at.</param>
    /// <param name="num">Number of ball being placed.</param>
    /// <returns>The instantiated ball created at the given position.</returns>
    public GameObject PlacePoolBall(HexWorldGrid hexGrid, Vector2Int pos, int num)
    {
        Vector3 worldPos = hexGrid.GetWorldPosition(pos);
        Quaternion worldRot = hexGrid.GetWorldRotation(pos);
        Quaternion randomRot = Random.rotation;
        Quaternion targetRot = Quaternion.Lerp(worldRot, randomRot, 0.5f);
        balls[num-1].transform.position = worldPos;
        balls[num-1].transform.rotation = targetRot;
        balls[num-1].SetActive(true);
        return balls[num-1];
    }
}