using System;

namespace API.Models
{
    public class spSelectCategory
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string PhotoImage { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserName { get; set; }
    }
}
