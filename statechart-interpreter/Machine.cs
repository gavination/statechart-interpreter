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

        public void Toggle(string eventName)
        {

        }
    }

    public class State
    {
        public string name { get; set; }
        public StateEvent[] stateEvents { get; set; }
        public State(StateEvent[] possibleEvents, string stateName )
        {
            this.name = stateName;
            this.stateEvents = possibleEvents;

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
