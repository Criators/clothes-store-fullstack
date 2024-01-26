using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Enums
{
    public enum PurchaseStatus
    {
        WaitingConfirmation = 1,
        WaitingPayment = 2,
        PaymentConfirmed = 3,
        SentForDelivery  = 4,
        DeliveryConfirmed = 5,
        CancelledPurchase = 6,
        CancelledDelivery = 7
    }
}
