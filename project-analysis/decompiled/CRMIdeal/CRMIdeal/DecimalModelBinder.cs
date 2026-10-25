using System;
using System.Globalization;
using System.Web.Mvc;

namespace CRMIdeal;

public class DecimalModelBinder : IModelBinder
{
	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
	{
		ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
		ModelState modelState = new ModelState
		{
			Value = value
		};
		object result = null;
		if (value.AttemptedValue != string.Empty)
		{
			try
			{
				result = Convert.ToDecimal(value.AttemptedValue, CultureInfo.CurrentCulture);
			}
			catch (FormatException exception)
			{
				modelState.Errors.Add(exception);
			}
		}
		bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
		return result;
	}
}
