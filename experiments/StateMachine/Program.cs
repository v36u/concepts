using StateMachine;

var claim = new Claim();

Console.WriteLine("=== Simple Insurance Claim State Machine ===");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Mermaid graph:");

Console.WriteLine();

Console.WriteLine(claim.GenerateMermaidGraph());

Console.WriteLine();

Console.WriteLine("Experiments:");

Console.WriteLine();

claim.ExecuteTransition(Claim.Trigger.UserSubmit);

claim.ExecuteTransition(Claim.Trigger.UserStart);

claim.ExecuteTransition(Claim.Trigger.UserAddInfo);

claim.ExecuteTransition(Claim.Trigger.UserAddInfo);

claim.ExecuteTransition(Claim.Trigger.UserSubmit);

claim.ExecuteTransition(Claim.Trigger.UserAddInfo);

claim.HasRequiredInfo = true;

claim.ExecuteTransition(Claim.Trigger.UserAddInfo);

claim.ExecuteTransition(Claim.Trigger.UserSubmit);

claim.ExecuteTransition(Claim.Trigger.UserAddInfo);

claim.ExecuteTransition(Claim.Trigger.OperatorApprove);

claim.IsDataOk = true;

claim.ExecuteTransition(Claim.Trigger.OperatorApprove);

claim.ExecuteTransition(Claim.Trigger.UserWithdraw);

claim.ExecuteTransition(Claim.Trigger.OperatorDeny);

claim.ExecuteTransition(Claim.Trigger.Unknown);