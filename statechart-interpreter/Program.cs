// See https://aka.ms/new-console-template for more information
using statechart_interpreter;

Console.WriteLine("FSM Time");

Console.WriteLine("Creating Events...");
var playEvent = new TransitionEvent("play", "PLAY", "Playing");
var pauseEvent = new TransitionEvent("pause", "PAUSE", "Paused");
var events = new List<TransitionEvent>
{
    playEvent,
    pauseEvent
};

Console.WriteLine("Creating StateNodes...");
var playingStateNode = new StateNode("playing", events);
var pausedStateNode = new StateNode("paused", events);


playingStateNode.setTargetNode(pausedStateNode);
pausedStateNode.setTargetNode(playingStateNode);


var stateNodes = new List<StateNode> { 
    pausedStateNode,
    playingStateNode
};

Console.WriteLine("Creating Machine Actor....");
var machineActor = new StateMachine("Video Player", pausedStateNode, stateNodes);

Console.WriteLine($"Initial State: {machineActor.InitialState.Name}");

Console.WriteLine("Sending an Event....");
machineActor.Transition(machineActor.CurrentState, playEvent);

Console.WriteLine($"Current State: {machineActor.CurrentState.Name}");






