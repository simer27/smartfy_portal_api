using System.ComponentModel.DataAnnotations.Schema;

namespace smartfy.portal_api.domain.Entities
{
    public class ModelSnapshot : Entity
    {
        [Column(TypeName = "jsonb")]
        public string Body { get; set; }
    }
}
