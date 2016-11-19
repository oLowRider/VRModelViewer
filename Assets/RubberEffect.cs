/*********************************************************************************************************
 * RUBBER EFFECT*
 * You need to set the Vertex Colors of your 3d model, on your prefered 3d Modelling Tool                  *
 * by Rodrigo Pegorari - 2010 - [url]
http://rodrigopegorari.net[/url]                                                 *
 * based on the Processing 'Chain' code example([url]http://www.processing.org/learning/topics/chain.html[/url])     *
 * ******************************************************************************************************* */
 
using UnityEngine;
using System.Collections;
 
public class RubberEffect : MonoBehaviour
{

    public RubberType Presets;

    public enum RubberType
    {
        Custom,
        RubberDuck,
        HardRubber,
        Jelly,
        SoftLatex
    }

    public float EffectIntensity = 1;
    public float gravity = 0;
    public float damping = 0.7f;
    public float mass = 1;
    public float stiffness = 0.2f;


    private Mesh WorkingMesh;
    private Mesh OriginalMesh;
    private float[] ColorIntensity;
    private VertexRubber[] vr;

    internal class VertexRubber
    {
        public float v_gravity;
        public float v_mass;
        public float v_stiffness;
        public float v_damping;
        public Vector3 pos;

        Vector3 vel = new Vector3();

        public VertexRubber(Vector3 v_target, float m, float g, float s, float d)
        {
            v_gravity = g;
            v_mass = m;
            v_stiffness = s;
            v_damping = d;

            pos = v_target;
        }

        public void update(Vector3 target)
        {

            Vector3 force = new Vector3();
            Vector3 acc = new Vector3();

            force.x = (target.x - pos.x) * v_stiffness;
            acc.x = force.x / v_mass;
            vel.x = v_damping * (vel.x + acc.x);
            pos.x += vel.x;

            force.y = (target.y - pos.y) * v_stiffness;
            force.y -= v_gravity / 10;
            acc.y = force.y / v_mass;
            vel.y = v_damping * (vel.y + acc.y);
            pos.y += vel.y;

            force.z = (target.z - pos.z) * v_stiffness;
            acc.z = force.z / v_mass;
            vel.z = v_damping * (vel.z + acc.z);
            pos.z += vel.z;

        }

    }


    void Start()
    {

        Debug.Log(Presets);
        MeshFilter filter = (MeshFilter)GetComponent(typeof(MeshFilter));
        OriginalMesh = filter.sharedMesh;

        WorkingMesh = Instantiate(filter.sharedMesh) as Mesh;
        filter.sharedMesh = WorkingMesh;

        ColorIntensity = new float[OriginalMesh.vertices.Length];

        vr = new VertexRubber[OriginalMesh.vertices.Length];

        for (int i = 0; i < OriginalMesh.vertices.Length; i++)
        {
            ColorIntensity[i] = (1 - ((OriginalMesh.colors[i].r + OriginalMesh.colors[i].g + OriginalMesh.colors[i].b) / 3)) * EffectIntensity;
            vr[i] = new VertexRubber(transform.TransformPoint(OriginalMesh.vertices[i]), mass, gravity, stiffness, damping);
        }

    }


    void LateUpdate()
    {

        checkPreset();

        Vector3[] V3_WorkingMesh = OriginalMesh.vertices;


        for (int i = 0; i < V3_WorkingMesh.Length; i++)
        {
            if (!float.Equals(ColorIntensity[i], 0f))
            {

                Vector3 v3_target = transform.TransformPoint(V3_WorkingMesh[i]);

                vr[i].v_gravity = gravity;
                vr[i].v_mass = mass;
                vr[i].v_stiffness = stiffness;
                vr[i].v_damping = damping;

                vr[i].update(v3_target);

                v3_target = transform.InverseTransformPoint(vr[i].pos);

                V3_WorkingMesh[i] = Vector3.Lerp(V3_WorkingMesh[i], v3_target, ColorIntensity[i] * EffectIntensity);

            }

        }

        WorkingMesh.vertices = V3_WorkingMesh;
        WorkingMesh.RecalculateBounds();

    }

    void checkPreset()
    {

        switch (Presets)
        {
            case RubberType.HardRubber:
                gravity = 0f;
                mass = 8f;
                stiffness = 0.5f;
                damping = 0.9f;
                EffectIntensity = 0.5f;
                break;
            case RubberType.Jelly:
                gravity = 0f;
                mass = 1f;
                stiffness = 0.95f;
                damping = 0.95f;
                EffectIntensity = 1f;
                break;
            case RubberType.RubberDuck:
                gravity = 0f;
                mass = 2f;
                stiffness = 0.5f;
                damping = 0.85f;
                EffectIntensity = 1f;
                break;
            case RubberType.SoftLatex:
                gravity = 1f;
                mass = 0.9f;
                stiffness = 0.3f;
                damping = 0.25f;
                EffectIntensity = 1f;
                break;
        }

    }

}