# Online Ordering Project

This project implements a simple online ordering system using classes and encapsulation in C#. It demonstrates how objects can work together to represent a real-world order process.

## What was created

The project includes the following classes:

- `Address`: stores the street, city, state/province, and country. It also includes a method to check whether the address is in the USA and another method to return the full address as a string.
- `Customer`: stores the customer information, including ID, name, email, and address. It also has a method to determine whether the customer lives in the USA.
- `Product`: represents each product with an ID, name, price, and stock quantity. It also includes methods to reduce or increase stock.
- `Order`: contains the order ID, date, customer, and a list of products. It calculates the total cost of the order, includes shipping cost, and generates the packing and shipping labels.
- `OrderDetail`: represents a single product line within an order, including product, quantity, unit price, and subtotal.
- `Payment`: is an abstract base class for payment types.
- `CardPayment` and `CashPayment`: concrete payment classes that inherit from `Payment` and implement the payment processing logic.
- `OrderStatus`: an enum that defines the possible order states such as Pending, Paid, Shipped, and Cancelled.

## Main responsibilities

### Address
The `Address` class keeps all address information private and exposes it through properties. This follows the principle of encapsulation, because the internal data is protected and only accessible through controlled methods.

### Customer
The `Customer` class stores the buyer's information and includes their address. It also checks whether the customer is in the USA by calling the address validation method.

### Product
The `Product` class stores product data and manages stock updates. This makes the product logic clean and controlled instead of allowing direct changes from outside the class.

### Order
The `Order` class is the main class that brings everything together. It collects products, calculates totals, and creates the information needed for shipping and packing.

The order total is computed as:

- subtotal of all products
- plus shipping cost
- minus any customer discount

Shipping is calculated based on the customer's country:

- USA: $5
- Other countries: $35

### Payment
The payment classes show polymorphism in a simple way. Each payment type implements the same `Process` method, but its logic may differ depending on the payment type.

## Example in the program

The `Program.cs` file creates sample customers, products, and orders, then prints:

- the packing label
- the shipping label
- the total cost of each order
- the payment status

This shows how the different classes work together to simulate a real online shopping process.

## Summary

This project demonstrates core object-oriented programming ideas such as:

- encapsulation
- classes and objects
- relationships between classes
- data validation
- inheritance and polymorphism
- practical business logic in software

The program is intentionally simple, but it shows how a real ordering system can be structured in a clean and organized way.
