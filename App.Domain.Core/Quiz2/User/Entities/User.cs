using App.Domain.Core.Quiz2.Card.Entities;

namespace App.Domain.Core.Quiz2.User.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<App.Domain.Core.Quiz2.Card.Entities.Card> Cards { get; set; }
    }
}
