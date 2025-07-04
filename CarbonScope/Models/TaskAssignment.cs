namespace CarbonScope.Models
{
    public class TaskAssignment : BaseEntity
    {
        public Guid AssignedUserId { get; set; }
        public ApplicationUser AssignedUser { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

}
