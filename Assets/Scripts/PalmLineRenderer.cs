using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PalmLineRenderer : MonoBehaviour
{
    public Transform PalmTransform; // Assign this to the palm transform
    public float LineLength = 0.5f; // Length of the line away from the palm

    private LineRenderer m_lineRenderer;
    private OVRHand m_hybeamHand;

    private void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();

        // Set the number of line positions (start and end)
        m_lineRenderer.positionCount = 2;

        TryGetComponent<OVRHand>(out m_hybeamHand);
    }

    private void Update()
    {
        if (m_hybeamHand != null)
        {
            if (!m_hybeamHand.IsPointerPoseValid)
            {
                DrawLineFromPalm();
            }
            else
            {
                ResetLine();
            }
        }
        else
        {
            ResetLine();
        }
    }

    private void DrawLineFromPalm()
    {
        if (PalmTransform == null) return;

        if (m_lineRenderer.positionCount < 2) m_lineRenderer.positionCount = 2;

        Vector3 startPosition = PalmTransform.position; // Center of the palm
        // Assuming the palm's forward direction is the negative Z-axis
        Vector3 endPosition = startPosition - PalmTransform.up * LineLength;

        // Set the positions for the LineRenderer
        m_lineRenderer.SetPosition(0, startPosition);
        m_lineRenderer.SetPosition(1, endPosition);
    }

    private void ResetLine()
    {
        m_lineRenderer.positionCount = 0;
    }
}
