using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statechart_interpreter
{
    public class StateMachine
    {
        public string Name { get; set; }
        public StateNode InitialState { get; set; }
        public StateNode CurrentState { get; private set; }
        public List<StateNode> StateNodes { get; set; }
        public StateMachine(string machineName, StateNode initialState, List<StateNode> possibleStates) { 
            Name = machineName;
            InitialState = initialState;
            CurrentState = initialState;
            StateNodes = possibleStates;
        }
        public StateNode Transition (StateNode stateNode, TransitionEvent sEvent)
        {
            if (sEvent == null || stateNode == null)
            {
                throw new ArgumentNullException("Please provide a State Event and a State");
            }

            // check to see if this is a legal move

            if (stateNode.stateEvents.Contains(sEvent))
            {
                if (stateNode.target != null)
                {
                    CurrentState = stateNode.target;
                    return stateNode.target;

                }
                else
                {
                    // no transition to make
                    // note: probs an unnecessary assignment
                    CurrentState = stateNode;
                    return stateNode;
                }
            }
            else
            {
                throw new Exception("Invalid State provided");
            }
        }

    }

    public class StateNode

    {
        public string Name { get; set; }
        // only legal moves belong in the stateEvents array
        public List<TransitionEvent> stateEvents { get; set; }
        public StateNode? target { get; set; }
        public StateNode(string stateName, List<TransitionEvent> possibleEvents, StateNode targetStateNode = null )
        {
            Name = stateName;
            stateEvents = possibleEvents;
            target = targetStateNode;

        }

        public void setTargetNode(StateNode targetStateNode)
        {
            target = targetStateNode;
        }
    }

    public class TransitionEvent
    {
        public string eventName { get; set; }
        public string eventType { get; set; }
        public string targetState { get; set; }
        public TransitionEvent(string name, string type, string targetStateName)
        {
            eventName= name;
            eventType = type;
            targetState = targetStateName;
        }
    }
}
