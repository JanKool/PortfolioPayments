using System;
using System.Text.Json.Serialization;

namespace PortfolioPayments.Models
{
    class Payment
    {
        [JsonPropertyName("paymentId")]
        public int PaymentId { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("paymentDate")]
        public DateTime PaymentDate { get; set; }
        [JsonPropertyName("settled")]
        public bool Settled { get; set; }
    }
}
