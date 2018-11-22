using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Enums
{
    public enum ProductType
    {
        /// <summary>
        /// A consumable product is a product for which stock is not managed.
        /// </summary>
        Consumable = 1,
        /// <summary>
        /// A storable product is a product for which you manage stock.
        /// </summary>
        Service = 2,
        /// <summary>
        /// A service is a non-material product you provide.
        /// </summary>
        Storable = 3,
        /// <summary>
        /// For Tourism a room is a product that have its own caracteristics like price calculation base in 1 person in double.
        /// </summary>
        Room = 4
    }
}
