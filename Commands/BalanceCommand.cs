namespace Hexapod.Commands;

public class BalanceCommand
{
    public bool Balance { get; set; }

    public override string ToString() => $"{Commands.CMD_BALANCE}#{(Balance ? 1 : 0)}";
}
