using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private BlockSpawner blockSpawner;
    private LaunchPreview launchPreview;
    private List<Ball> balls = new List<Ball>();
    private int ballsReady;
    private bool ballsWasReturn = true;
 

    [SerializeField]
    private Ball ballPrefab;
    [SerializeField]
    private float gravityBall = 0.01f;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
        ballsReady = balls.Count;
        Debug.Log(ballsReady + " Awake Methode");
      //  GetComponent<LineRenderer>().SetWidth(0f, 0f);
        GetComponent<LineRenderer>().startWidth = 0f;
        GetComponent<LineRenderer>().endWidth = 0f;
    }

    public void ReturnBall()
    {
        ballsReady++;
        Debug.Log(ballsReady + " ReturnBall Methode");
        if (ballsReady == balls.Count)
        {
            blockSpawner.SpawnRowOfBlocks();
            if (balls.Count < 100)
            {
                CreateBall();
            }
            ballsWasReturn = true;
        }
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        ballsReady++;
        Debug.Log(ballsReady + " CreateBall Methode");
    }

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;
        if (ballsWasReturn && Time.timeScale == 1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartDrag(worldPosition);
            }
            else if (Input.GetMouseButton(0))
            {
                ContinueDrag(worldPosition);
                GetComponent<LineRenderer>().startWidth = 0.05f;
                GetComponent<LineRenderer>().endWidth = 0.05f;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }
    }

    private void EndDrag()
    {
        if (endDragPosition != startDragPosition && endDragPosition.y < startDragPosition.y && startDragPosition.y - endDragPosition.y > 0.3)
        {
            StartCoroutine(LaunchBalls());
            ballsWasReturn = false;
        }
        GetComponent<LineRenderer>().startWidth = 0f;
        GetComponent<LineRenderer>().endWidth = 0f;
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);
            ball.GetComponent<Rigidbody2D>().gravityScale = gravityBall;
            ballsReady--;
            Debug.Log(ballsReady + " LaunchBalls Methode");
            yield return new WaitForSeconds(0.1f);
        }
      //  ballsReady = 0;
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;

        Vector3 direction = endDragPosition - startDragPosition;

        if (endDragPosition != startDragPosition && endDragPosition.y < startDragPosition.y && startDragPosition.y - endDragPosition.y > 0.3)
        {
            GetComponent<LineRenderer>().startColor = new Color32(201, 53, 250, 255);
            GetComponent<LineRenderer>().endColor = new Color32(201, 53, 250, 255);
        }
        else
        {
            GetComponent<LineRenderer>().startColor = new Color32(95, 25, 116, 255);
            GetComponent<LineRenderer>().endColor = new Color32(95, 25, 116, 255);
        }

        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launchPreview.SetStartPoint(transform.position);
    }
}
