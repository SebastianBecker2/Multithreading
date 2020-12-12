using System.ComponentModel;
using System.Windows.Forms;

public static class ISynchronizeInvokeExtensions
{
	public static void InvokeIfRequired(this ISynchronizeInvoke @object, MethodInvoker action)
	{
		if (@object.InvokeRequired)
		{
			@object.Invoke(action, new object[0]);
		}
		else
		{
			action();
		}
	}
}