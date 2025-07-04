namespace CarbonScope.Dtos
{
    public class TaskAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid AssignedUserId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

}
