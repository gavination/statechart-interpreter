using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statechart_interpreter
{
    public class Machine
    {
        public string name { get; set; }
        public State InitialState { get; set; }
        public State[] States { get; set; }
        public Machine(string machineName, State InitialState, State[] possibleStates) { 
            this.name = machineName;
            this.InitialState = InitialState;
            this.States = possibleStates;

        }

        public State Transition (State state, StateEvent sEvent)
        {
            if (sEvent == null || state == null)
            {
                throw new ArgumentNullException("Please provide a State Event and a State");
            }

            // check to see if this is a legal move
            if (state.stateEvents.Contains(sEvent))
            {
                return state.target;
            }
            else
            {
                throw new Exception("Invalid State provided");
            }
        }

    }

    public class State
    {
        public string name { get; set; }
        public StateEvent[] stateEvents { get; set; }
        public State? target { get; set; }
        public State(StateEvent[] possibleEvents, string stateName, State targetState = null )
        {
            this.name = stateName;
            this.stateEvents = possibleEvents;
            this.target = targetState;

        }
    }

    public class StateEvent
    {
        public string eventName { get; set; }
        public string eventType { get; set; }
        public string targetState { get; set; }
        public StateEvent(string name, string type, string targetStateName)
        {
            this.eventName= name;
            this.eventType = type;
            this.targetState = targetStateName;
        }
    }
}
