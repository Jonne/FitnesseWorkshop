package nl.devnology.domain.customer;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Erik Pragt
 */
public class Customers {
    private static List<Customer> customers = new ArrayList<Customer>();

    public static void add(Customer customer) {
        if(customers.contains(customer)) {
            throw new IllegalArgumentException("Customer " + customer + " already known.");
        }

        customers.add(customer);
    }

    public static Customer findByName(String customerName) {
        for(Customer customer : customers) {
            if(customer.getName().equals(customerName)) {
                return customer;
            }
        }

        return null;
    }
}
