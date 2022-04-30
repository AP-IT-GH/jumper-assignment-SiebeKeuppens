using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class HansDasKubus : Agent
{
    Rigidbody m_Rigidbody;
    public Transform Obstacle; //The obstacle comes towards the agent and the agent has to jump over it.
    public Transform ObstacleVertical; //The obstacle comes towards the agent and the agent has to jump over it.
    public float speedMultiplier = 0.5f;
    bool Hitting = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        RaycastHit ObstacleHit;
        Ray ObstacleRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ObstacleRay, out ObstacleHit, 5f)){
            if(ObstacleHit.collider.tag == "Obstacle" && Hitting == false){
                AddReward(2f);
                Hitting = true;
            }
        }
    }
    

    public override void OnEpisodeBegin()
    {
        Obstacle.gameObject.SetActive(true);

        // If the Agent fell, zero its momentum, reset its position, and count as a loss.
        if (transform.localPosition.y < 0)
        {
            m_Rigidbody.angularVelocity = Vector3.zero;
            m_Rigidbody.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = new Quaternion(0, 0, 0, 1);
            SetReward(-2f);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Vector3 controlSignal = Vector3.zero;
        transform.Translate(controlSignal * speedMultiplier);
        controlSignal.y = actionBuffers.DiscreteActions[0];
        //If the signal is given and the agent is on the ground, jump.
        if (controlSignal.y == 1 && transform.localPosition.y == 0.5f)
        {
            m_Rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            AddReward(-1f);
        }

        //Did the agent fall?
        else if (transform.localPosition.y < 0)
        {
            EndEpisode();
        }
        //Is the agent standing on the ground?
        else if (transform.localPosition.y == 0.5f)
        {
            Hitting = false;
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //Allow the user to jump.
        var jump = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.Space))
            jump[0] = 1;
    }
}
