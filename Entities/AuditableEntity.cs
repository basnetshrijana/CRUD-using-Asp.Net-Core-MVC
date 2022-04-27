namespace BookMvc.Entities
{
    public class AuditableEntity : IdentifiableEntity
    {
         public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

      
        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}