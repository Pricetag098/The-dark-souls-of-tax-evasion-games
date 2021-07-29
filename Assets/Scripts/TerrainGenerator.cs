using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class TerrainGenerator : MonoBehaviour
{
    public bool reGenMap;
    Mesh mesh;
    MeshCollider meshCollider;
    public int xSize = 20, zSize = 20;

    Vector3[] vertices;
    Vector2[] Uvs;
    int[] triangles;
    Color[] colors;
    public int octaves = 1;
    public float scale = .3f;
    public float percistance = 1;
    public float lanacurity = 1;

    public GameObject[] objectSpawns;


    public static float seed = 0;

    float minHeight = 0, maxHeight = 0;
    public Gradient gradient;

    public float offsetX = 0, offsetZ = 0;


    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshCollider = gameObject.GetComponent<MeshCollider>();
        if (seed == 0)
        {
            seed = Random.Range(0, 9999);
        }
        CreateShape();
        UpdateMesh();
    }

    private void Update()
    {
        if (reGenMap)
        {
            CreateShape();
            UpdateMesh();
        }



    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        Uvs = new Vector2[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Perlin(x, z);
                vertices[i] = new Vector3(x, y, z);

                if (y < minHeight)
                    minHeight = y;
                if (y > maxHeight)
                    maxHeight = y;
                //if (objectSpawns.Length > 0) { GenObjects(x, y, z); }
                Uvs[i] = new Vector2(x, z);

                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        triangles = new int[6 * xSize * zSize];
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
        /*
        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minHeight,maxHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }
        */
    }

    float Perlin(float x, float z)
    {
        float amplitude = 1;
        float frequncy = 1;
        float y = 0;

        for (int i = 0; i < octaves; i++)
        {
            float xCoord = (x / xSize) / scale * frequncy + offsetX + seed + transform.position.x;
            float zCoord = (z / zSize) / scale * frequncy + offsetZ + seed + transform.position.z;

            float perlinVal = Mathf.PerlinNoise(xCoord, zCoord) * -1;

            y += perlinVal * amplitude;

            amplitude *= percistance;
            frequncy *= lanacurity;
        }



        return y;
    }


    void GenObjects(float x, float y, float z)
    {
        float randVal = Random.value;
        if (randVal > .999)
        {
            int randObj = Random.Range(0, objectSpawns.Length);
            GameObject newGo = Instantiate(objectSpawns[randObj], new Vector3(x + transform.position.x, y + transform.position.y, z + transform.position.z), transform.rotation, this.transform);

        }


    }



    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = Uvs;
        //mesh.colors = colors;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshCollider.sharedMesh = mesh;
    }
}