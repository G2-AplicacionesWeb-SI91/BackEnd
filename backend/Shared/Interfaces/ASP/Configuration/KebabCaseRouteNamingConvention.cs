using backend.Shared.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace backend.Shared.Interfaces.ASP.Configuration;

public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?
                    .Replace("[controller]", name.ToKebabCase())
            }
            : null;
    }
    public void Apply(ControllerModel controller)
    {
        throw new NotImplementedException();
    }
}