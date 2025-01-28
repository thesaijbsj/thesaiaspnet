using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CRUDEF.CustomValidation
{
	public class SkillsValidate : Attribute, IModelValidator
	{
		public string[] Allowed { get; set; }
		public string ErrorMessage { get; set; }
		public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
		{

			if (Allowed.Contains(context.Model as string))
				return Enumerable.Empty<ModelValidationResult>();
			else
				return new List<ModelValidationResult> {
					new ModelValidationResult("", ErrorMessage)
				};
		}
	}
}
