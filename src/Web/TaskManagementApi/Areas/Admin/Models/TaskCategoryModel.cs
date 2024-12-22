using Swashbuckle.AspNetCore.Annotations;

namespace TaskManagementApi.Areas.Admin.Models
{
    public class TaskCategoryModel
    {
        [SwaggerIgnore]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
