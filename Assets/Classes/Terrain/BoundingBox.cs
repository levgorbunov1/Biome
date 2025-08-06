using UnityEngine;

public class ZoneBoundary2DWall : MonoBehaviour
{
    [Header("Zone Dimensions")]
    public float zoneWidth = 50f;
    public float zoneHeight = 20f;
    public float zoneDepth = 50f;

    [Header("Optional")]
    public bool showDebugGizmos = true;

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        Vector3 center = transform.position;


        CreateWall("LeftWall", new Vector3(center.x - zoneWidth / 2f, center.y, center.z), new Vector3(0f, zoneHeight, zoneDepth));
        CreateWall("RightWall", new Vector3(center.x + zoneWidth / 2f, center.y, center.z), new Vector3(0f, zoneHeight, zoneDepth));
        CreateWall("FrontWall", new Vector3(center.x, center.y, center.z + zoneDepth / 2f), new Vector3(zoneWidth, zoneHeight, 0f));
        CreateWall("BackWall", new Vector3(center.x, center.y, center.z - zoneDepth / 2f), new Vector3(zoneWidth, zoneHeight, 0f));
        CreateWall("TopWall", new Vector3(center.x, center.y + zoneHeight / 2f, center.z), new Vector3(zoneWidth, 0f, zoneDepth));
        CreateWall("BottomWall", new Vector3(center.x, center.y - zoneHeight / 2f, center.z), new Vector3(zoneWidth, 0f, zoneDepth));
    }

    void CreateWall(string name, Vector3 position, Vector3 size)
    {
        GameObject wall = new GameObject(name);
        
        wall.transform.position = position;
        wall.transform.parent = this.transform;

        BoxCollider collider = wall.AddComponent<BoxCollider>();
        collider.size = size;
    }

    void OnDrawGizmos()
    {
        if (!showDebugGizmos) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(zoneWidth, zoneHeight, zoneDepth));
    }
}
