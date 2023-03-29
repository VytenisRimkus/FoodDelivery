using FoodDelivery.Interfaces;

namespace FoodDelivery.App
{
    public class Order : IElement, IEquatable<Order>
    {
        public Guid OrderNumber { get; }
        public string Name { get; }
        public string Description => ToString();
        public DateTime _orderDate { get; }
        public List<MenuItem>? _orderedItems { get; }

        public decimal _totalCost
        {
            get
            {
                decimal totalCost = 0;
                if (_orderedItems != null)
                {
                    foreach (var item in _orderedItems)
                    {
                        totalCost += item._price;
                    }
                }
                return totalCost;
            }
        }

        public Order()
        {
            OrderNumber = Guid.NewGuid();
            _orderDate = DateTime.UtcNow;
            Name = $"{OrderNumber} {_orderDate}";
            _orderedItems = new List<MenuItem>();
        }

        public void AddMenuItemToOrder(MenuItem item)
        {
            _orderedItems.Add(item);
        }

        public void RemoveMenuItemFromOrder(MenuItem item)
        {
            _orderedItems.Remove(item);
        }

        public override string ToString()
        {
            string orderItemsString = "";
            if (_orderedItems != null)
            {
                foreach (MenuItem orderItem in _orderedItems)
                {
                    orderItemsString += orderItem.ToString() + "\n";
                }

            }
            return $"Order #{OrderNumber}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Order order = (Order)obj;
            return OrderNumber == order.OrderNumber;
        }

        public bool Equals(Order? other)
        {
            if (ReferenceEquals(other, this))
                return true;

            if (other == null)
                return false;

            if (other.Name != Name
                || other.Description != Description
                || other._totalCost != _totalCost
                || other._orderDate != _orderDate
                || other._orderedItems != _orderedItems)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return OrderNumber.GetHashCode();
        }

        public static bool operator ==(Order a, Order b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Order a, Order b)
        {
            if (a == b)
                return false;

            return true;
        }
    }
}