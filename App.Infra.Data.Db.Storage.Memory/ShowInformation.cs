using App.Domain.Core.Quiz2.Card.Entities;

namespace App.Infra.Data.Db.Storage.Memory
{
    public static class ShowInformation
    {
        public static string SourceCardNumber { get; set; }
        public static Card DestinationsCard { get; set; }
        public static float Amount { get; set; }
        public static string CodeVerify { get; set; }
    }
}
