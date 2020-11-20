using System;

namespace smartfy.portal_api.application.ViewModels
{
    public class VigilanciaSaudeViewModel
    {

        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public bool Excluded { get; set; }

        public Guid VigilanciaSaudeId { get; set; }

        public string NomeVigilancia { get; set; }
    }
}
