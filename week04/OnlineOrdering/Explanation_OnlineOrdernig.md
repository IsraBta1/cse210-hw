# Online Ordering Project

This project is an interactive online ordering system built in C# using object-oriented programming. It follows the same class design as the diagram prepared in the assignment and focuses on the concept of encapsulation. The program allows the user to enter customer data, add products to an order, calculate totals, generate shipping labels, and process a payment.

## Overview

The system is composed of several classes that work together to represent a real online shopping process. Each class has a specific responsibility and keeps its internal data private, exposing only what is necessary through methods and properties.

## Classes implemented

### Address
The `Address` class stores:
- street address
- city
- state or province
- country

It also has methods to:
- determine whether the address is in the USA
- return the complete address as one formatted string

This class helps the order know whether shipping should be charged as domestic or international.

### Customer
The `Customer` class stores:
- customer ID
- name
- email
- address
- frequent discount

It includes a method to verify whether the customer lives in the USA by using the address information. This keeps the design organized and follows the idea that a customer is not just a name, but a full object with important information.

### Product
The `Product` class represents each item for sale with:
- product ID
- name
- unit price
- stock quantity

It also has methods to:
- reduce stock when a product is added to an order
- increase stock when necessary

This allows the program to manage product inventory in a controlled way.

### OrderDetail
The `OrderDetail` class represents one item inside an order. It stores:
- the product
- quantity selected
- unit price
- subtotal

This class helps keep each individual line item separate before calculating the total of the full order.

### Order
The `Order` class is the central part of the system. It contains:
- order ID
- date
- customer
- order status
- list of order details

It includes methods to:
- add products to the order
- calculate the total cost
- generate a packing label
- generate a shipping label
- process payment
- cancel the order

The total is calculated using the sum of all product subtotals, plus the shipping cost, minus any discount if applicable.

### Payment
The `Payment` class is an abstract base class used to define common behavior for all payment types. It stores:
- transaction ID
- success status

Its main method is `Process`, which is implemented differently by each child class.

### CardPayment and CashPayment
These classes inherit from `Payment` and implement the payment logic for each payment type.

- `CardPayment` simulates a credit or debit card transaction.
- `CashPayment` simulates a cash payment.

This demonstrates inheritance and polymorphism in a simple and effective way.

### OrderStatus
The `OrderStatus` enum stores the possible states of an order, such as:
- Pending
- Paid
- Shipped
- Cancelled

## How the program works

The `Program.cs` file creates an interactive menu in the console. The user can:

1. enter customer information
2. select products from a catalog
3. choose how many of each product to buy
4. keep adding items to the order
5. review the packing label
6. review the shipping label
7. see the total amount
8. choose a payment method
9. complete the order

This approach makes the system user-friendly while still keeping the same object-oriented structure from the class diagram.

## OOP principles used

This project demonstrates several concepts of object-oriented programming:

- Encapsulation: private fields and controlled access through methods and properties
- Inheritance: `CardPayment` and `CashPayment` inherit from `Payment`
- Polymorphism: all payment classes use the same `Process` method name but implement it differently
- Composition: an `Order` contains many `OrderDetail` objects and a `Customer`
- Abstraction: the program hides implementation details and exposes only useful actions

## Summary

The online ordering project is a simple but complete example of how classes can model a real business process. It shows how multiple objects interact to create an order, calculate prices, prepare shipping labels, and handle payment. This is a good foundation for learning the relationship between classes and how to apply encapsulation and object-oriented design in C#.
