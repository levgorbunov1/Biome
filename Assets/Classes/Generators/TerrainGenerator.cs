// using UnityEngine;
// using System.Collections.Generic;

// [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
// public class ProceduralPlanet : MonoBehaviour
// {
//     [SerializeField] private int subdivisions = 4; // Higher = smoother sphere
//     [SerializeField] private float radius = 10f;
//     [SerializeField] private float noiseStrength = 1f;
//     [SerializeField] private float noiseScale = 1f;
//     [SerializeField] private int seed = 0;

//     private Mesh mesh;
//     private List<Vector3> vertices;
//     private List<int> triangles;

//     void OnEnable()
//     {
//         GenerateSphere();
//     }

//     void GenerateSphere()
//     {
//         // Use a cube-based sphere (for simplicity)
//         GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//         MeshFilter tempMeshFilter = temp.GetComponent<MeshFilter>();

//         mesh = Instantiate(tempMeshFilter.sharedMesh);
//         Destroy(temp);

//         GetComponent<MeshFilter>().mesh = mesh;

//         // Deform vertices using noise
//         Vector3[] verts = mesh.vertices;
//         Vector3[] normals = mesh.normals;

//         System.Random prng = new System.Random(seed);
//         float offsetX = (float)prng.NextDouble() * 9999f;
//         float offsetY = (float)prng.NextDouble() * 9999f;

//         for (int i = 0; i < verts.Length; i++)
//         {
//             Vector3 vertex = verts[i].normalized;
//             float noise = Mathf.PerlinNoise(
//                 vertex.x * noiseScale + offsetX,
//                 vertex.z * noiseScale + offsetY
//             );

//             verts[i] = vertex * (radius + noise * noiseStrength);
//         }

//         mesh.vertices = verts;
//         mesh.RecalculateNormals();
//         mesh.RecalculateBounds();
//     }
// }
