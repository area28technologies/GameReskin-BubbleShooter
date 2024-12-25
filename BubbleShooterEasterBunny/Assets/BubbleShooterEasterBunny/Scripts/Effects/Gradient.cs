using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect
{
    [SerializeField]
    private Color32 topColor = Color.white;
    [SerializeField]
    private Color32 bottomColor = Color.black;

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        if (vertexList.Count == 0)
        {
            return;
        }

        // Xác định Y lớn nhất và Y nhỏ nhất
        float bottomY = vertexList[0].position.y;
        float topY = vertexList[0].position.y;

        foreach (var vertex in vertexList)
        {
            float y = vertex.position.y;
            if (y > topY)
            {
                topY = y;
            }
            else if (y < bottomY)
            {
                bottomY = y;
            }
        }

        float uiElementHeight = topY - bottomY;

        // Áp dụng gradient cho mỗi vertex
        for (int i = 0; i < vertexList.Count; i++)
        {
            UIVertex uiVertex = vertexList[i];
            uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
            vertexList[i] = uiVertex;
        }

        // Cập nhật lại VertexHelper với các vertex đã chỉnh sửa
        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }
}