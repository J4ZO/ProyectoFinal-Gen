using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
    public List<Material> objMaterials;

    // Update is called once per frame
    void Update()
    {
        CombineMeshMaterial();
    }

    private void CombineMeshMaterial()
    {
        MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
        List<Mesh> subMeshes = new List<Mesh>();
        List<Material> materials = new List<Material>();

        Vector3 initialPosition = transform.position;
        transform.position = Vector3.zero;

        foreach(Material material in objMaterials)
        {
            List<CombineInstance> combiner_per_material = new List<CombineInstance>();

            foreach(MeshFilter m in meshFilters)
            {
                MeshRenderer rendere = m.GetComponent<MeshRenderer>();
                Material[] Material = rendere.sharedMaterials;
                
                for (int i = 0; i < Material.Length; i++)
                {
                    if(Material[i] == material)
                    {
                        CombineInstance combiner = new CombineInstance();
                        combiner.mesh = m.sharedMesh;
                        combiner.subMeshIndex = i;
                        combiner.transform = m.transform.localToWorldMatrix;
                        combiner_per_material.Add(combiner);
                    }
                }

            }
            Mesh mesh = new Mesh();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            mesh.CombineMeshes(combiner_per_material.ToArray(), true);
            subMeshes.Add(mesh);
        }
        List<CombineInstance> combiners_final = new List<CombineInstance>();
        CombineInstance combine;
        foreach(Mesh mesh in subMeshes)
        {
            combine = new CombineInstance();
            combine.mesh = mesh;
            combine.subMeshIndex = 0;
            combine.transform = Matrix4x4.identity;
            combiners_final.Add(combine);
        }

        Mesh meshfinal = new Mesh();
        meshfinal.CombineMeshes(combiners_final.ToArray(),false);
        transform.GetComponent<MeshFilter>().sharedMesh = meshfinal;
        transform.GetComponent<MeshRenderer>().sharedMaterials = materials.ToArray();
        transform.position = initialPosition;

        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
