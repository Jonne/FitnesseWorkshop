package nl.devnology.domain.customer;

/**
 * @author Erik Pragt
 */
public class Customer {
    private String name;
    private Integer money;

    public Customer(String name, Integer money) {
        this.name = name;
        this.money = money;
    }

    public String getName() {
        return name;
    }

    public Integer getMoney() {
        return money;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Customer customer = (Customer) o;

        if (!name.equals(customer.name)) return false;

        return true;
    }

    @Override
    public int hashCode() {
        return name.hashCode();
    }

    public void deductMoney(Integer money) {
        this.money -= money;
    }
}
