using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Extentions;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Camera Camera;
    public List<GameObject> PossibleSegments;

    private List<GameObject> _segments;

    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<GameObject>();
        _segments.Add(Instantiate(PossibleSegments[0]));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var cameraBounds = Camera.OrthographicBounds();

        var firstSegmentEnd = _segments.First().GetComponent<Segment>().End.transform.position;
        var lastSegmentEnd = _segments.Last().GetComponent<Segment>().End.transform.position;

        var isFirstGonePast = cameraBounds.min.x > firstSegmentEnd.x;
        var isLastInside = cameraBounds.max.x > lastSegmentEnd.x;

        if (isLastInside)
        {
            AddSegment();
        }

        if (isFirstGonePast)
        {
            RemoveSegment();
        }
    }

    private void RemoveSegment()
    {
        var firstSegment = _segments.First();
        Destroy(firstSegment);
        _segments.Remove(firstSegment);
    }

    private void AddSegment()
    {
        var newSegment = Instantiate(PossibleSegments[Random.Range(0, PossibleSegments.Count )]);
        var newSegmentStartPosition = newSegment.GetComponent<Segment>().Start.transform.position;
        var newSegmentPositionDelta = newSegment.transform.position - newSegmentStartPosition;

        var prevSegmentsEndPosition = _segments.Last().GetComponent<Segment>().End.transform.position;
        var positionDelta = newSegmentPositionDelta + prevSegmentsEndPosition;

        newSegment.transform.position += positionDelta;
        _segments.Add(newSegment);

    }
}
