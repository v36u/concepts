// Simple Insurance Claim State Machine

using Stateless;
using Stateless.Graph;

namespace StateMachine;

public class Claim
{
    private readonly StateMachine<State, Trigger> _stateMachine = new(State.PendingStart);

    public bool HasRequiredInfo { get; set; }

    public bool IsDataOk { get; set; }

    private enum State
    {
        Unknown,

        PendingStart,
        Draft,
        Submitted,
        Approved,
        Denied,
        Closed
    }

    public enum Trigger
    {
        Unknown,

        UserStart,
        UserAddInfo,
        UserSubmit,
        UserWithdraw,

        OperatorApprove,
        OperatorDeny
    }

    public Claim()
    {
        _stateMachine.OnTransitioned(OnTransitioned);
        _stateMachine.OnUnhandledTrigger(OnUnhandledTrigger);

        _stateMachine.Configure(State.PendingStart)
            .Permit(Trigger.UserStart, State.Draft)
            .Permit(Trigger.UserWithdraw, State.Closed);

        _stateMachine.Configure(State.Draft)
            .PermitReentry(Trigger.UserAddInfo)
            .Permit(Trigger.UserWithdraw, State.Closed)
            .PermitIf(Trigger.UserSubmit, State.Submitted, () => HasRequiredInfo);

        _stateMachine.Configure(State.Submitted)
            .Permit(Trigger.UserWithdraw, State.Closed)
            .Permit(Trigger.OperatorDeny, State.Denied)
            .PermitIf(Trigger.OperatorApprove, State.Approved, () => IsDataOk);
    }

    public void ExecuteTransition(Trigger trigger)
    {
        _stateMachine.Fire(trigger);
    }

    public string GenerateMermaidGraph()
    {
        return MermaidGraph.Format(_stateMachine.GetInfo());
    }

    private static void OnTransitioned(StateMachine<State, Trigger>.Transition transition)
    {
        Console.WriteLine(
            $"Transitioned from the `{transition.Source}` state to the `{transition.Destination}` state, via the `{transition.Trigger}` trigger");
    }

    private void OnUnhandledTrigger(State state, Trigger trigger)
    {
        Console.WriteLine($"Cannot use the `{trigger}` trigger to execute transition from the `{state}` state");
    }
}