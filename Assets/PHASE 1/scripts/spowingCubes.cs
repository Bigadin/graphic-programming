
using UnityEngine;

public class spowingCubes : MonoBehaviour
{
    [SerializeField] int resolution;
    [SerializeField] float step;
    [SerializeField] Transform pointPrefab;
    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        //var position = Vector3.zero;
        points = new Transform[resolution * resolution];
        for (int i = 0; i < points.Length; i++)
        {
            //if (x == resolution) {
            //	x = 0;
            //	z += 1;
            //}
            Transform point = points[i] = Instantiate(pointPrefab);
            //position.x = (x + 0.5f) * step - 1f;
            //position.z = (z + 0.5f) * step - 1f;
            //point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
    [SerializeField] int function = 0;
    private void Update()
    {
        FonctionLib.funciton current_f = FonctionLib.getFunc(function);
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            //float v = (z + 0.5f) * step - 1f;
            points[i].localPosition = current_f(u, v, Time.time);
        }
    }

}
