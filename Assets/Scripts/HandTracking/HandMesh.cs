using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HandMesh : MonoBehaviour
{
  int[] handnum;
  int[] meshtriangles;
  MeshRenderer meshRenderer_;
  MeshFilter filter;
  HandTrackingManager handTrackingmanager;
    List<FingerPosition> fingerpositionlist => handTrackingmanager.fingerpositionlist;
  public HandMesh Initialize(HandTrackingManager _handTrackingmanager)
  {
    handnum = new int[]
    {
      0,1,2,5,9,13,17
    };
    meshRenderer_ = GetComponent<MeshRenderer>();
    meshtriangles = new int[] {
                0 ,6, 5,
                0, 5, 4,
                0, 4, 3,
                0, 3, 2,
                0, 2, 1,
                0, 1, 2,
                0, 2, 3,
                0, 3, 4,
                0, 4, 5,
                0, 5, 6
            };
    filter = GetComponent<MeshFilter>();

        return this;
    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
      fingerpositionlist[handnum[0]].thistransform.position,
      fingerpositionlist[handnum[1]].thistransform.position,
      fingerpositionlist[handnum[2]].thistransform.position,
      fingerpositionlist[handnum[3]].thistransform.position,
      fingerpositionlist[handnum[4]].thistransform.position,
      fingerpositionlist[handnum[5]].thistransform.position,
      fingerpositionlist[handnum[6]].thistransform.position,
            };
        mesh.triangles = meshtriangles;
        mesh.RecalculateNormals();
        filter.mesh = mesh;
    }
}
