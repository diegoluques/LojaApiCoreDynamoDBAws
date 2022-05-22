using Amazon.DynamoDBv2.DataModel;

namespace SharedApiCore.Domain.Bases
{
    public class EntityBase
    {
        protected EntityBase()
        {
            CreatedByUser = new();
        }

        public User CreatedByUser { get; set; }
        public DateTime CreationDate { get; set; }
        public User ModifiedByUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public User()
        {
            UserId = Guid.NewGuid();
            UserName = "Diego Luques";
        }
    }
}
