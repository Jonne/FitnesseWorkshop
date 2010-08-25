package nl.devnology.fitnesse.amasun.customer;

import nl.devnology.domain.customer.Customer;
import nl.devnology.domain.customer.Customers;

/**
 * @author Erik Pragt
 */
public class IntializeCustomerBase {
    private String name;
    private Integer money;

    public void execute() {
        Customers.add(new Customer(name, money));
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setMoney(Integer money) {
        this.money = money;
    }
}
