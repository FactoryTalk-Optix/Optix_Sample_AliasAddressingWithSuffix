#region Using directives
using System.Linq;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using UAManagedCore;
#endregion

public class FaceplateAliasesLogic : BaseNetLogic
{
    public override void Start()
    {
        // Get to the main alias
        var mainAlias = InformationModel.GetVariable(LogicObject.GetVariable("MainAlias").Value) ?? null;
        if (mainAlias == null)
        {
            Log.Error("FaceplateAliasesLogic.Start", "MainAlias variable cannot be reached, make sure is not empty");
            return;
        }
        // Get to the node pointed by the main alias
        var mainAliasValue = InformationModel.Get(mainAlias.Value) ?? null;
        if (mainAliasValue == null)
        {
            Log.Error("FaceplateAliasesLogic.Start", "MainAlias is empty, make sure it points to a tag");
            return;
        }
        // Get the other aliases (must start with "Alias_")
        foreach (var variable in mainAlias.Owner.Children.OfType<IUAVariable>().Where(t => t.BrowseName.StartsWith("Alias")))
        {
            Log.Debug("FaceplateAliasesLogic.Start.Foreach", "Found alias named: " + variable.BrowseName);
            var targetVar = mainAliasValue.Owner.Get(mainAliasValue.BrowseName + variable.BrowseName.Replace("Alias", "")) ?? null;
            if (targetVar != null)
            {
                variable.Value = targetVar.NodeId;
            }
            else
            {
                Log.Error("FaceplateAliasesLogic.Start.Foreach", "Cannot find any Tag matching: " + mainAliasValue.BrowseName + variable.BrowseName.Replace("Alias", ""));
            }
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
