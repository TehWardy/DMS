using DMS.Objects.Entities;
using Microsoft.OData.Edm;

namespace DMS.Api.EDM
{
    public class DMSModelBuilder : ODataModelBuilder
    {
        public override ODataModel Build() => new()
        {
            Context = "DMS",
            Description = "DMS Endpoints for the Platform.",
            EDMModel = BuildModel()
        };

        IEdmModel BuildModel()
        {
            // common stuff
            AddCommonComplextypes();



            return Builder.GetEdmModel();
        }
    }
}