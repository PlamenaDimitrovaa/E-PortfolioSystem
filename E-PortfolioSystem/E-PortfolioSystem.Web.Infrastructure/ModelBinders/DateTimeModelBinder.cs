using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace E_PortfolioSystem.Web.Infrastructure.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None && string.IsNullOrWhiteSpace(valueProviderResult.FirstValue))
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                try
                {
                    var valueAsString = valueProviderResult.FirstValue;

                    var dateTime = DateTime.ParseExact(valueAsString!, "dddd, dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture);


                    bindingContext.Result = ModelBindingResult.Success(dateTime);

                    return Task.CompletedTask;

                }
                catch (Exception fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }
            }

            return Task.CompletedTask;
        }
    }
}
