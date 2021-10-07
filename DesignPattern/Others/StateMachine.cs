using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Others
{
    /* 
    Let’s say that you are designing an e-commerce site which has a shopping cart and you are given the following requirements.
    * You can only pay for a cart once.
    * Once a cart is paid for, you cannot change the items in it.
    * Empty carts cannot be paid for. */

    public record Product(string Name, double Price);

    public interface ICart
    {
        string GetDisplay();
    }

    public interface IAddProduct
    {
        ICart AddProduct(Product product);
    }

    public interface IRemoveProduct
    {
        ICart RemoveProduct(Product product);
    }

    public interface IPayCart
    {
        ICart Pay();
    }

    public class EmptyCart : ICart, IAddProduct
    {
        public ICart AddProduct(Product product)
        {
            return new ActiveCart(new List<Product> { product });
        }

        public string GetDisplay()
            => "Empty Cart";
    }

    public class ActiveCart : ICart, IAddProduct, IPayCart, IRemoveProduct
    {
        public IEnumerable<Product> UnpaidItems { get; } = new List<Product>();

        public ActiveCart(IEnumerable<Product> products)
        {
            UnpaidItems = products;
        }

        public ICart AddProduct(Product product)
        {
            return new ActiveCart(new List<Product>(UnpaidItems) { product });
        }

        public ICart Pay()
        {
            return new PaidCart(UnpaidItems);
        }

        public string GetDisplay()
            => $"Active Cart: [{string.Join(',', UnpaidItems)}]";

        public ICart RemoveProduct(Product product)
        {
            var remainingItems = UnpaidItems.Where(item => item != product);

            if (remainingItems.Any())
                return new ActiveCart(remainingItems);

            return new EmptyCart();
        }
    }

    public class PaidCart : ICart
    {
        public IEnumerable<Product> PaidItems { get; } = new List<Product>();

        public double Amount { get; } = 0;

        public PaidCart(IEnumerable<Product> products)
        {
            PaidItems = products;
            Amount = products
                .Select(product => product.Price)
                .Sum();
                //.Aggregate((a, e) => a + e);
        }

        public string GetDisplay()
            => $"Paid Cart: (Amount: {Amount}) [{string.Join(',', PaidItems)}]";
    }

    public class ShoppingCart
    {
        private readonly ICart _cart;

        public ShoppingCart(ICart cart)
            => _cart = cart;

        public ShoppingCart()
            : this(new EmptyCart())
        {
        }

        public ShoppingCart AddProduct(Product product)
        {
            if (_cart is IAddProduct cartAdder)
                return new ShoppingCart(cartAdder.AddProduct(product));

            return this;
        }

        public ShoppingCart RemoveProduct(Product product)
        {
            if (_cart is IRemoveProduct cartRemover)
                return new ShoppingCart(cartRemover.RemoveProduct(product));

            return this;
        }

        public ShoppingCart Pay()
        {
            if (_cart is IPayCart cartPayer)
                return new ShoppingCart(cartPayer.Pay());

            return this;
        }

        public void Display()
            => Console.WriteLine(_cart.GetDisplay());
    }

    public class CartClient
    {
        public void UseCart()
        {
            var cart = new ShoppingCart();
            cart.Display();

            var biscuit = new Product("Biscuit", 2.5);
            var fromage = new Product("Fetta", 4.1);

            cart = cart.AddProduct(biscuit);
            cart.Display();

            cart = cart.RemoveProduct(biscuit);
            cart.Display();

            cart = cart.RemoveProduct(biscuit);
            cart.Display();

            cart.Pay();
            cart.Display();

            cart = cart.AddProduct(fromage);
            cart = cart.AddProduct( biscuit);
            cart.Display();

            cart = cart.Pay();
            cart.Display();
        }
    }
}
